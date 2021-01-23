    using System.IO;
    using System.Timers;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    using System.ServiceProcess;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net;
    using System.Web;
    namespace WinServiceSample
    {
    public partial class ScheduledService : ServiceBase
    {
        
        Timer timer;
        
        public ScheduledService()
        {
            InitializeComponent();
            if (!System.Diagnostics.EventLog.SourceExists("MyLogSrc"))
            {
                System.Diagnostics.EventLog.CreateEventSource("MyLogSrc", "MyLog");
            }
            myEventLog.Source = "MyLogSrc";
            myEventLog.Log = "MyLog";
            timer = new Timer(10000);
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
        }
        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            WebClient wc = new WebClient();
            string reply = wc.DownloadString("http://www.nalcorenergy.com/hydro/scrape1.asp");
            myEventLog.WriteEntry(reply);
        }
        protected override void OnStart(string[] args)
        {
            myEventLog.WriteEntry("Its Started");
           
            
            timer.Enabled = true;
            
        }
        protected override void OnStop()
        {
            timer.Enabled = false;
            
            myEventLog.WriteEntry("She no go");
        }
       
        
        
    }
    }
