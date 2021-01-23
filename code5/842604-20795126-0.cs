    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
      public partial class Form1 : Form
      {
        Queue<Record> recordQ;
        WebClient wc;
        NetSpeedCounter counter;
        
        public Form1()
        {
          InitializeComponent();
          recordQ = new Queue<Record>();
          //recordQ.Enqueue(new Record(@"URI1", "SQLtraining.exe"));//replace the URI string
          //recordQ.Enqueue(new Record(@"URI2", "Project Mgmt.pptx"));
          
          //first uri to process
          Record record = new Record(@"URI0","Agile.pptx"); // replace the URI
    
          
          using (wc = new WebClient())
          {
            counter = new NetSpeedCounter(wc);
            wc.DownloadFileCompleted += (sender, e) =>
            {
              if (recordQ.Count == 0)
              {
                UpdateStatusText("Done");
                return;
              }
              var nr = recordQ.Dequeue();
              
              CheckAndCreate(nr.Directory);
    
              this.Invoke((MethodInvoker)delegate
              {
                  UpdateStatusText("Downloading " + recordQ.Count + " files");
              });
              counter.Reset();
              counter.Start();
              wc.DownloadFileAsync(nr.DownloadPath, nr.Directory+nr.File);
              this.lblFile.Text = nr.DownloadPath.OriginalString;
            };
            wc.DownloadProgressChanged += wc_DownloadProgressChanged;
            counter.Start();
            this.lblFile.Text = record.DownloadPath.OriginalString;
            wc.DownloadFileAsync(record.DownloadPath, record.Directory+record.File);
          }
          
        }
    
        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
          this.lblSpeed.Text = counter.Speed.ToString();
        }
        public void UpdateStatusText(string msg)
        {
          this.lblStatus.Text = msg;
        }
        public void CheckAndCreate(string absPath)
        {
          if (!Directory.Exists(absPath))
            Directory.CreateDirectory(absPath);
        }   
        
      }
      public class NetSpeedCounter
      {
        private DateTime LastUpdate;
        private int NumCounts = 0;
        private int PrevBytes = 0;
        private Stopwatch stopwatch;
        public double Speed { get; private set; }
        double[] DataPoints;
        public NetSpeedCounter(WebClient webClient, int maxPoints = 10)
        {
          DataPoints = new double[maxPoints];
          stopwatch = new Stopwatch();
          Array.Clear(DataPoints, 0, DataPoints.Length);
          webClient.DownloadProgressChanged += (sender, e) =>
          {
            var msElapsed = DateTime.Now - LastUpdate;
    
            stopwatch.Stop();
            int curBytes = (int)(e.BytesReceived - PrevBytes);
            PrevBytes = (int)e.BytesReceived;
    
            double dataPoint = (double)curBytes / (stopwatch.ElapsedMilliseconds); //record in kbps
            DataPoints[NumCounts++ % maxPoints] = dataPoint;
            if (NumCounts == Int32.MaxValue)
              NumCounts = 0;
    
            Speed = DataPoints.Average();
            stopwatch.Start();
          };
        }
    
        public void Start()
        {
          LastUpdate = DateTime.Now;
          stopwatch.Start();
        }
    
        public void Reset()
        {
            PrevBytes = 0;
            LastUpdate = DateTime.Now;
            stopwatch.Reset();
        }
      }
      public class Record
      {
        public string Directory;
        public string File;
        public Uri DownloadPath;
        public Record(string uriPath, string fileOutputName)
        {
          this.Directory = @"C:\TestDir\";
          this.DownloadPath = new Uri(uriPath);
          this.File = fileOutputName;
        }
        public string GetFullPath()
        {
          return this.Directory + this.File;
        }
      }  
      
    }
