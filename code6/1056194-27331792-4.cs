    using System;
    using System.ComponentModel;
    using System.Threading;
    namespace BusyIndicatorExample
    {
    /// <summary>
    /// Abortable background worker
    /// </summary>
    public class AbortableBackgroundWorker : BackgroundWorker
    {
        //Internal Thread
        private Thread workerThread;
        protected override void OnDoWork(DoWorkEventArgs e)
        {
            try
            {
                base.OnDoWork(e);
            }
            catch (ThreadAbortException)
            {
                e.Cancel = true;        //We must set Cancel property to true! 
                Thread.ResetAbort();    //Prevents ThreadAbortException propagation 
            }
        }
        public void Abort()
        {
            if (workerThread != null)
            {
                workerThread.Abort();
                workerThread = null;
            }
        }
    } 
    }
