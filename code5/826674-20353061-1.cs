    public static void AppendToFile(string fileName, string text){
        var gl = new GlobalNamedLock(fileName);
        if(!gl.Lock()){
             // should not happen
             // but still throw the exception some how to notice
             throw new InvalidOperationException("Could not acquire lock");
        }
  
        try{
            File.AppendAllText(fileName, text);
        }finally{
            gl.Unlock();
        }
    }
    public class GlobalNamedLock
    {
        private Mutex mtx;
        public GlobalNamedLock(string strLockName)
        {
            //Name must be provided!
            if (string.IsNullOrWhiteSpace(strLockName))
            {
                //Use default name
                strLockName = ((GuidAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), false).GetValue(0)).Value.ToString();
            }
            //Create security permissions for everyone
            //It is needed in case the mutex is used by a process with
            //different set of privileges than the one that created it
            //Setting it will avoid access_denied errors.
            MutexSecurity mSec = new MutexSecurity();
            mSec.AddAccessRule(new MutexAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null),
                MutexRights.FullControl, AccessControlType.Allow));
            //Create the global mutex
            bool bCreatedNew;
            mtx = new Mutex(false, @"Global\" + strLockName, out bCreatedNew, mSec);
        }
        public bool Lock()
        {
            return mtx.WaitOne();
        }
        public void Unlock()
        {
            //Release it
            mtx.ReleaseMutex();
        }
    }
