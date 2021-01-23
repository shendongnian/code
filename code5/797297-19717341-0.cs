        public class MutexLocker: IDisposable
        {
            private Mutex _mutex;
            public MutexLocker ( string id )
            {
                bool createdNew;
                MutexSecurity mutexSecurity = new MutexSecurity();
                mutexSecurity.AddAccessRule(new MutexAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), 
                                                                MutexRights.Synchronize | MutexRights.Modify, AccessControlType.Allow));
                try
                {
                    // attempt to create the mutex, with the desired DACL..
                    _mutex = new Mutex(false, id, out createdNew, mutexSecurity);
                }
                catch (WaitHandleCannotBeOpenedException)
                {
                    // the mutex cannot be opened, probably because a Win32 object of a different
                    // type with the same name already exists.
                    throw;
                }
                catch (UnauthorizedAccessException)
                {
                    // the mutex exists, but the current process or thread token does not
                    // have permission to open the mutex with SYNCHRONIZE | MUTEX_MODIFY rights.
                    throw;
                }
            }
            public void Dispose ()
            {
                if (_mutex != null)
                {
                    _mutex.ReleaseMutex();
                    _mutex.Dispose();
                }
                _mutex = null;
            }
        }
