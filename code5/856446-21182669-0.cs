    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Auth;
    using Microsoft.WindowsAzure.Storage.Blob;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials("accountname", "accountkey"), true);
            static void Main(string[] args)
            {
                CloudBlobClient myBlobClient = storageAccount.CreateCloudBlobClient();
                myBlobClient.SingleBlobUploadThresholdInBytes = 1024 * 1024;
                CloudBlobContainer container = myBlobClient.GetContainerReference("adokontajnerneki");
                //container.CreateIfNotExists();
                CloudBlockBlob myBlob = container.GetBlockBlobReference("cfx.zip");
                var blockSize = 256 * 1024;
                myBlob.StreamWriteSizeInBytes = blockSize;
                var fileName = @"D:\cfx.zip";
                long bytesToUpload = (new FileInfo(fileName)).Length;
                long fileSize = bytesToUpload;
                
                if (bytesToUpload < blockSize)
                {
                    CancellationToken ca = new CancellationToken();
                    var ado = myBlob.UploadFromFileAsync(fileName, FileMode.Open, ca);
                    Console.WriteLine(ado.Status); //Does Not Help Much
                    ado.ContinueWith(t =>
                    {
                        Console.WriteLine("Status = " + t.Status);
                        Console.WriteLine("It is over"); //this is working OK
                    });
                }
                else
                {
                    List<string> blockIds = new List<string>();
                    int index = 1;
                    long startPosition = 0;
                    long bytesUploaded = 0;
                    do
                    {
                        var bytesToRead = Math.Min(blockSize, bytesToUpload);
                        var blobContents = new byte[bytesToRead];
                        using (FileStream fs = new FileStream(fileName, FileMode.Open))
                        {
                            fs.Position = startPosition;
                            fs.Read(blobContents, 0, (int)bytesToRead);
                        }
                        ManualResetEvent mre = new ManualResetEvent(false);
                        var blockId = Convert.ToBase64String(Encoding.UTF8.GetBytes(index.ToString("d6")));
                        Console.WriteLine("Now uploading block # " + index.ToString("d6"));
                        blockIds.Add(blockId);
                        var ado = myBlob.PutBlockAsync(blockId, new MemoryStream(blobContents), null);
                        ado.ContinueWith(t =>
                        {
                            bytesUploaded += bytesToRead;
                            bytesToUpload -= bytesToRead;
                            startPosition += bytesToRead;
                            index++;
                            double percentComplete = (double)bytesUploaded / (double)fileSize;
                            Console.WriteLine("Percent complete = " + percentComplete.ToString("P"));
                            mre.Set();
                        });
                        mre.WaitOne();
                    }
                    while (bytesToUpload > 0);
                    Console.WriteLine("Now committing block list");
                    var pbl = myBlob.PutBlockListAsync(blockIds);
                    pbl.ContinueWith(t =>
                    {
                        Console.WriteLine("Blob uploaded completely.");
                    });
                }
                Console.ReadKey();
            }
        }
    }
