    using System;
    using System.IO;
    using System.Security.AccessControl;
    using System.Security.Principal;
    using System.Threading;
    namespace ConsoleApplication31
    {
        class Program
        {
            private static SMutex mclsIOLock;
            static void Main(string[] args)
            {
                string strEnumStorageFilePath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "MyAppEnumStorage.txt");
                mclsIOLock = IOMutexGet(strEnumStorageFilePath);
            }
            //Template for the main processing routine.
            public static void RequestProcess()
            {
                bool blnLockIsSet = false;
                try
                {
                    //Obtain the lock.
                    blnLockIsSet = IOLockSet(mclsIOLock);
                    //Read file data, update file data.
                    //...
                }
                finally
                {
                    //Release the lock if it was obtained in this particular call stack frame.
                    IOLockRelease(mclsIOLock, blnLockIsSet);
                }
            }
            private static SMutex IOMutexGet(string iMutexNameBase)
            {
                SMutex clsResult = null;
                clsResult = new SMutex();
                string strSystemObjectName = @"Global\" + iMutexNameBase.Replace('\\', '_');
                //Give permissions to all authenticated users.
                SecurityIdentifier clsAuthenticatedUsers = new SecurityIdentifier(WellKnownSidType.AuthenticatedUserSid, null);
                MutexSecurity clsMutexSecurity = new MutexSecurity();
                MutexAccessRule clsMutexAccessRule = new MutexAccessRule(
                    clsAuthenticatedUsers,
                    MutexRights.FullControl,
                    AccessControlType.Allow);
                clsMutexSecurity.AddAccessRule(clsMutexAccessRule);
                //Create the mutex or open an existing one.
                bool blnCreatedNew;
                clsResult.Mutex = new Mutex(
                    false,
                    strSystemObjectName,
                    out blnCreatedNew,
                    clsMutexSecurity);
                clsResult.IsMutexHeldByCurrentAppDomain = false;
                return clsResult;
            }
            //Release IO lock.
            private static void IOLockRelease(
                SMutex iLock,
                bool? iLockIsSetInCurrentStackFrame = null)
            {
                if (iLock != null)
                {
                    lock (iLock)
                    {
                        if (iLock.IsMutexHeldByCurrentAppDomain &&
                            (!iLockIsSetInCurrentStackFrame.HasValue ||
                            iLockIsSetInCurrentStackFrame.Value))
                        {
                            iLock.MutexOwnerThread = null;
                            iLock.IsMutexHeldByCurrentAppDomain = false;
                            iLock.Mutex.ReleaseMutex();
                        }
                    }
                }
            }
            //Set the IO lock.
            private static bool IOLockSet(SMutex iLock)
            {
                bool blnResult = false;
                try
                {
                    if (iLock != null)
                    {
                        if (iLock.MutexOwnerThread != Thread.CurrentThread)
                        {
                            blnResult = iLock.Mutex.WaitOne();
                            iLock.IsMutexHeldByCurrentAppDomain = blnResult;
                            if (blnResult)
                            {
                                iLock.MutexOwnerThread = Thread.CurrentThread;
                            }
                        }
                        if (!blnResult)
                        {
                            throw new ApplicationException("Не удалось получить монопольный доступ к теневой копии сборок.");
                        }
                    }
                }
                catch (AbandonedMutexException iMutexAbandonedException)
                {
                    blnResult = true;
                    iLock.IsMutexHeldByCurrentAppDomain = true;
                    iLock.MutexOwnerThread = Thread.CurrentThread;
                }
                return blnResult;
            }
        }
        internal class SMutex
        {
            public Mutex Mutex;
            public bool IsMutexHeldByCurrentAppDomain;
            public Thread MutexOwnerThread;
        }
    }
