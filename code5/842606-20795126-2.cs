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
        //We store downloaded files in C:\TestDir (hardcoded in the Record class below)
        public Form1()
        {
          InitializeComponent();
          recordQ = new Queue<Record>();
          //replace the URI string below. Nothing else to replace.
          //recordQ.Enqueue(new Record(@"URI1", "SQLtraining.exe"));
          //recordQ.Enqueue(new Record(@"URI2", "Project Mgmt.pptx"));
          
          //first uri to process. Second param is the file name that we store.
          Record record = new Record(@"URI0","Agile.pptx"); // replace the URI
    
          //Initialize a webclient and download the first record
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
              //just create directory. the code uses the same directory
              CheckAndCreate(nr.Directory);
    
              this.Invoke((MethodInvoker)delegate
              {
                  UpdateStatusText("Left to process: " + recordQ.Count + " files");
              });
              counter.Reset();
              counter.Start();
              //continue with rest of records
              wc.DownloadFileAsync(nr.DownloadPath, nr.Directory+nr.File);
              this.lblFile.Text = nr.DownloadPath.OriginalString;
            };
            //just update speed in UI
            wc.DownloadProgressChanged += wc_DownloadProgressChanged;
            counter.Start();
            //display URI we are downloading
            this.lblFile.Text = record.DownloadPath.OriginalString;
            //start first download
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
            //record in kbps
            double dataPoint = (double)curBytes / (stopwatch.ElapsedMilliseconds); 
            DataPoints[NumCounts++ % maxPoints] = dataPoint;
            //protect NumCount from overflow
            if (NumCounts == Int32.MaxValue)
              NumCounts = 0;
    
            Speed = DataPoints.Average();
            stopwatch.Start();
          };
        }
    
        public void Start()
        {
          stopwatch.Start();
        }
    
        public void Reset()
        {
            PrevBytes = 0;            
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
