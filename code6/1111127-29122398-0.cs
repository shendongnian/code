    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Threading;
    
    namespace WindowsFormsApplication1
    {
     public partial class Form1 : Form
     {
      public Form1()
      {
       InitializeComponent();
       this.Load += new EventHandler(Form1_Load);
      }
    
      void Form1_Load(object sender, EventArgs e)
      {
       ScannerUtility util = new ScannerUtility(SynchronizationContext.Current);
       util.EnableScannerUtility();
       util.HeartBeatMessage = "Waiting for scanner...";
    
       this.SuspendLayout();
       Label lbl = new Label();
       lbl.Text = "Waiting for scanner...";
       lbl.Name = "lblTimer";
       lbl.Location = new System.Drawing.Point(15, 15);
       lbl.AutoSize = true;
       lbl.DataBindings.Add("Text", util, "HeartBeatMessage", false, DataSourceUpdateMode.OnPropertyChanged);
       this.Controls.Add(lbl);
       this.ResumeLayout(true);
      }
     }
    
     public partial class ScannerUtility : INotifyPropertyChanged
     {
      private SynchronizationContext _uiThreadContext;
      public System.Timers.Timer timerHeartBeat = new System.Timers.Timer();
      public DateTime lastHeartBeat = new DateTime();
      public string heartBeatMessage = string.Empty;
      public event PropertyChangedEventHandler PropertyChanged;
    
      public ScannerUtility(SynchronizationContext uiThreadContext)
      {
       _uiThreadContext = uiThreadContext;
      }
    
      private void NotifyPropertyChanged(String info)
      {
       if (PropertyChanged != null)
       {
        _uiThreadContext.Post(onUIPropertyChanged, new PropertyChangedEventArgs(info));
       }
       ;
      }
    
      private void onUIPropertyChanged(object state)
      {
        PropertyChanged(this, (PropertyChangedEventArgs)state);
      }
    
      public void EnableScannerUtility()
      {
       timerHeartBeat = new System.Timers.Timer();
       timerHeartBeat.AutoReset = true;
       timerHeartBeat.Interval = 5000;// 35000;
       timerHeartBeat.Elapsed += TimerHeartBeat_Elapsed;
       timerHeartBeat.Start();
      }
    
      private void TimerHeartBeat_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
      {
       TimeSpan timeSinceLastHeartbeat = DateTime.Now.ToUniversalTime() - lastHeartBeat;
       if (timeSinceLastHeartbeat > TimeSpan.FromSeconds(30))
       {
        HeartBeatMessage = "No Answer from Scanner";
       }
       else
       {
        HeartBeatMessage = "Scanner OK";
       }
      }
    
      public string HeartBeatMessage
      {
       get
       {
        return this.heartBeatMessage;
       }
    
       set
       {
        if (value != this.heartBeatMessage)
        {
         this.heartBeatMessage = value;
         NotifyPropertyChanged("HeartBeatMessage");
        }
       }
      }
     }
    }
