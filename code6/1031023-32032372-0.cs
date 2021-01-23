    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.WDTF;
    using System.Configuration;
    
    namespace ConnectedStandby_SleepAndWake
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                int CSDurationMilliseconds = 0;
                DateTime wakeTime = new DateTime();
                try
                {
                if (ConfigurationManager.AppSettings["wakeTime"] != null)
                {
                    wakeTime = Convert.ToDateTime(ConfigurationManager.AppSettings["wakeTime"]);
                }
                else
                {
                    wakeTime = DateTime.Now.AddMinutes(2);
                }
    
                System.TimeSpan wakeInMs = wakeTime.Subtract(DateTime.Now);
                CSDurationMilliseconds = wakeInMs.Milliseconds;
    
                IWDTF2 WDTF = new WDTF2();
                IWDTFSystemAction2 Sys = (IWDTFSystemAction2)WDTF.SystemDepot.ThisSystem.GetInterface("System");
                // Sys.SleepWakeTimeInSeconds = 60;
                // Sys.Sleep(4);
    
                Sys.ConnectedStandby(CSDurationMilliseconds);
                }
    
                catch (Exception e)
                {
                }
    
    
                
            }
        }
    }
