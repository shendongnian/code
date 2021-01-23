    using System.Threading;
	
    public static class StaticDisposer 
    {
        private static Thread mParentProcThread = null;
        private static Thread mDisposerThread = null;
      // Other class members:
            ………………………………………………
      // Objects to be disposed at the process exit:
      // Ex.: private/public static … obj1ToDispose = null;
            ………………………………………………
        static StaticDisposer()
        {
             mParentProcThread = Thread.CurrentThread;
             mDisposerThread = new Thread(DisposerThreadBody);
             mDisposerThread.Start();
        }
      // Methods of the class:
            ………………………………………………
        private static void DisposerThreadBody()
        {
            while (mParentProcThread != null && mParentProcThread.IsAlive)
            {
                Thread.Sleep(500);
            }
            // Dispose objects, release resources, close streams, delete temporary files, etc.:
            //if(obj1ToDispose != null)
            //    <Dispose code>
            //   ………………………………………………………………………………
        }
    }
