    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using Microsoft.WindowsAzure.Storage.Blob.Protocol;
    using System.Configuration;
    
    namespace TerminalManager.Domain.Foundation.BlobLeases
    {
        public class AutoRenewLease : IDisposable
        {
            public bool HasLease { get { return leaseId != null; } }
    
            AccessCondition _accessCondition;
            private CloudBlockBlob blob;
            private string leaseId;
            private Thread renewalThread;
            private bool disposed = false;
    
            public static void DoOnce(CloudBlockBlob blob, Action action) { DoOnce(blob, action, TimeSpan.FromSeconds(5)); }
            public static void DoOnce(CloudBlockBlob blob, Action action, TimeSpan pollingFrequency)
            {
                // blob.Exists has the side effect of calling blob.FetchAttributes, which populates the metadata collection
                while (!blob.Exists() || blob.Metadata["progress"] != "done")
                {
                    using (var arl = new AutoRenewLease(blob))
                    {
                        if (arl.HasLease)
                        {
                            action();
                            blob.Metadata["progress"] = "done";
                            AccessCondition ac = new AccessCondition();
                            ac.LeaseId = arl.leaseId;
                            blob.SetMetadata(ac);
                        }
                        else
                        {
                            Thread.Sleep(pollingFrequency);
                        }
                    }
                }
            }
    
            /// <summary>
            /// Выполнить последовательно
            /// </summary>
            /// <param name="lockBlobName">имя блоба - просто буквы</param>
            /// <param name="action"></param>
            /// <param name="cnStrName">из конфига</param>
            /// <param name="containerName">из конфига</param>
            /// <param name="pollingFrequency"></param>
            public static void DoConsequence(string lockBlobName, Action action, 
                string cnStrName = "StorageConnectionString", 
                string containerName = "leasesContainer", TimeSpan? pollingFrequency = null)
            {
                //http://www.windowsazure.com/en-us/develop/net/how-to-guides/blob-storage/
    
                // Формат пути к блобу
                //http://<storage account>.blob.core.windows.net/<container>/<blob>
                // Блобовский аккаунт
                var account = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings[cnStrName].ConnectionString); //CloudStorageAccount.Parse("UseDevelopmentStorage=true"); // Не работает на SDK 2.2 // or your real connection string
                var blobs = account.CreateCloudBlobClient();
                // Контейнер - типа папки
                var container = blobs
                    .GetContainerReference(ConfigurationManager.AppSettings[containerName]);
                container.CreateIfNotExists();
    
                var blob = container.GetBlockBlobReference(lockBlobName);
    
    
                bool jobDone = false;
    
                while (!jobDone)
                {
                    using (var arl = new AutoRenewLease(blob))
                    {
                        if (arl.HasLease)
                        {
                            // Some Sync Work here 
                            action();
                            jobDone = true;
                        }
                        else
                        {
                            Thread.Sleep(pollingFrequency ?? TimeSpan.FromMilliseconds(300));
                        }
                    }
                }
            }
    
            public static void DoEvery(CloudBlockBlob blob, TimeSpan interval, Action action)
            {
                while (true)
                {
                    var lastPerformed = DateTimeOffset.MinValue;
                    using (var arl = new AutoRenewLease(blob))
                    {
                        if (arl.HasLease)
                        {
                            blob.FetchAttributes();
                            DateTimeOffset.TryParseExact(blob.Metadata["lastPerformed"], "R", CultureInfo.CurrentCulture, DateTimeStyles.AdjustToUniversal, out lastPerformed);
                            if (DateTimeOffset.UtcNow >= lastPerformed + interval)
                            {
                                action();
                                lastPerformed = DateTimeOffset.UtcNow;
                                blob.Metadata["lastPerformed"] = lastPerformed.ToString("R");
                                AccessCondition ac = new AccessCondition();
                                ac.LeaseId = arl.leaseId;
                                blob.SetMetadata(ac);
                            }
                        }
                    }
                    var timeLeft = (lastPerformed + interval) - DateTimeOffset.UtcNow;
                    var minimum = TimeSpan.FromSeconds(5); // so we're not polling the leased blob too fast
                    Thread.Sleep(
                        timeLeft > minimum
                        ? timeLeft
                        : minimum);
                }
            }
    
            public AutoRenewLease(CloudBlockBlob blob)
            {
                this.blob = blob;
                blob.Container.CreateIfNotExists();
                try
                {
                    if (!blob.Exists())
                    {
                        blob.UploadFromByteArray(new byte[0], 0, 0, AccessCondition.GenerateIfNoneMatchCondition("*"));// new BlobRequestOptions { AccessCondition = AccessCondition.IfNoneMatch("*") });
                    }
                }
                catch (StorageException e)
                {
                    if (e.RequestInformation.HttpStatusCode != (int)HttpStatusCode.PreconditionFailed // 412 from trying to modify a blob that's leased
                        && e.RequestInformation.ExtendedErrorInformation.ErrorCode != BlobErrorCodeStrings.BlobAlreadyExists
                        )
                    {
                        throw;
                    }
                }
                try
                {
                    leaseId = blob.AcquireLease(TimeSpan.FromSeconds(60), null);
                    _accessCondition = new AccessCondition { LeaseId = leaseId };
                }
                catch (Exception)
                {
                    Trace.WriteLine("==========> Lease rejected! <==========");
                }
    
                if (HasLease)
                {
                    renewalThread = new Thread(() =>
                    {
                        while (true)
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(40));
                            var ac = new AccessCondition();
                            ac.LeaseId = leaseId;
                            blob.RenewLease(ac);//.RenewLease(leaseId);
                        }
                    });
                    renewalThread.Start();
                }
            }
    
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
    
            protected virtual void Dispose(bool disposing)
            {
                if (!disposed)
                {
                    if (disposing)
                    {
                        if (renewalThread != null)
                        {
                            renewalThread.Abort();
                            blob.ReleaseLease(_accessCondition);
                            renewalThread = null;
                        }
                    }
                    disposed = true;
                }
            }
    
            ~AutoRenewLease()
            {
                Dispose(false);
            }
        }
    }
