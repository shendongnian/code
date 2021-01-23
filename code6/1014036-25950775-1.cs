    using System;
    using BombaySapphireCds.Jobs;
    using Elmah;
    
    [assembly: WebActivator.PostApplicationStartMethod(typeof(BombaySapphireCds.App_Start.PodMonitorConfig), "Start")]
    [assembly: WebActivator.ApplicationShutdownMethod(typeof(BombaySapphireCds.App_Start.PodMonitorConfig), "Shutdown")]
    
    namespace BombaySapphireCds.App_Start
    {
        public static class PodMonitorConfig
        {
            private static PodMonitorJob m_job;
    
            public static void Start()
            {
                m_job = new PodMonitorJob(TimeSpan.FromSeconds(20));
            }
    
            public static void Shutdown()
            {
                m_job.Dispose();
            }
        }
    }
