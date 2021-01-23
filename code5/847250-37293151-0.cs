    public class HVCSensor : HVCDevice, IDisposable
    {
        private Thread myThread;
        private const int execute_timeout = ((10 + 10 + 6 + 3 + 15 + 15 + 1 + 1 + 15 + 10) * 1000);
        private bool disposed = false;
        private bool paused = false;
        public delegate void HVCResultsHandler(HVC_RESULT res);
        public event HVCResultsHandler HVCResultsArrived;
        private void OnHVCResultsArrived(HVC_RESULT res)
        {
            if (HVCResultsArrived != null) {
                HVCResultsArrived(res);
            }
        }
        public HVCSensor() {
            myThread = new Thread(new ThreadStart(this.execute));
            
        }
        private void execute(){
            while (!disposed) {
                if (!paused && this.IsConnected)
                {
                    HVC_RESULT outRes;
                    byte status;
                    try
                    {
                        
                        this.ExecuteEx(execute_timeout, activeDetections, imageAcquire, out outRes, out status);
                        OnHVCResultsArrived(outRes);
                    }
                    catch (Exception ex) {
                        
                    }
                    
                }
                else {
                    try
                    {
                        Thread.Sleep(1000);
                    }
                    catch (ThreadInterruptedException e)
                    {
 
                    }
                }
                
            
            }
        }
        public HVC_EXECUTION_IMAGE imageAcquire
        {
            get;
            set;
        }
        public HVC_EXECUTION_FLAG activeDetections
        {
            get;
            set;
        }
        public void startDetection() {
            if(myThread.ThreadState==ThreadState.Unstarted)
                myThread.Start();
        }
        public void pauseDetection() {
            paused = true;
        }
        public void resumeDetection() {
           
            paused = false;
            if (myThread.ThreadState == ThreadState.WaitSleepJoin)
                myThread.Interrupt();
        }
        // Implement IDisposable. 
        // Do not make this method virtual. 
        // A derived class should not be able to override this method. 
        public void Dispose()
        {
            disposed = true;
            myThread.Interrupt();
            
        }
    }
