    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace BombaySapphireCds.Jobs
    {
        public class PodMonitorJob : IDisposable
        {
            private CancellationTokenSource m_cancel;
            private Task m_task;
            private TimeSpan m_interval;
            private bool m_running;
    
            public PodMonitorJob(TimeSpan interval)
            {
                m_interval = interval;
                m_running = true;
                m_cancel = new CancellationTokenSource();
                m_task = Task.Run(() => TaskLoop(), m_cancel.Token);
            }
    
            private void TaskLoop()
            {
                while (m_running)
                {
                    //
                    // Do monitoring work here.
                    //
    
                    Thread.Sleep(m_interval);
                }
            }
    
            public void Dispose()
            {
                m_running = false;
    
                if (m_cancel != null)
                {
                    try
                    {
                        m_cancel.Cancel();
                        m_cancel.Dispose();
                    }
                    catch
                    {
                    }
                    finally
                    {
                        m_cancel = null;
                    }
                }
            }
        }
    }
