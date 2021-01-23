    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace BGWORKERAPP
    {
        public partial class Form1 : Form
        {
    
            BackgroundWorker bgWorker = new BackgroundWorker();
            public Form1()
            {
                InitializeComponent();
                bgWorker.DoWork += bw_DoWork;
                bgWorker.WorkerReportsProgress = true;        // needed to be able to report progress
                bgWorker.WorkerSupportsCancellation = true;   // needed to be able to stop the thread using CancelAsync();
                bgWorker.ProgressChanged += bw_ProgressChanged;
                bgWorker.RunWorkerCompleted += bw_RunWorkerCompleted;
    
                // ProgressBar is added to the form manually, and here I am just setting some initial values
                progressBarStatus.Maximum = 100;
                progressBarStatus.Minimum = 0;
                progressBarStatus.Value = 0;
                progressBarStatus.Step = 10;
            }
            void bw_DoWork(object sender, DoWorkEventArgs e)
            {
                int i = 0;
                while (true)    // keep looping until user presses the "Stop" button
                {
                    if (bgWorker.CancellationPending)   // if bgWorker.CancelAsync() is called, this CancelationPending token will be set,
                    {                                   // and if statement will be true
                        bgWorker.CancelAsync();
                        return;     // Thread is getting canceled, RunWorkerCompleted will be called next
                    }
    
                    i++;    // add any value you want, I chose this value because of the test example...
                    Thread.Sleep(1);    // give thread some time to report (1ms is enough for this example) - NECESSARY, 
                                        //WITHOUT THIS LINE, THE MAIN THREAD WILL BE BLOCKED!
                    bgWorker.ReportProgress(i); // report progress (will call bw_ProgressChanged) - NECESSARY TO REPORT PROGRESS!
                }
            }
            int somethingTerrible = 1;  // used to do something terrible ;)
            void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                // I added this "somethingTerrible" variable to make the ProgressChanged run all over again, even when e.ProgressPercentage value
                // is greater then the progressBarStatus.Maximum, but, you should call bw.CancelAsync() because the job should be finished.
                // Also, this code will give you Exception eventually, numbers are limited after all...
                if (somethingTerrible * progressBarStatus.Maximum == e.ProgressPercentage)
                {
                    Debug.WriteLine("THIS IS CALLED WHEN THE MAXIMUM IS REACHED");   // this will be printed in the Output window
                    progressBarStatus.Value = 0; // progressBarStatus value is at the maximum, restart it (or Exception will be thrown)
    
                    //bw.CancelAsync();   // used to stop the thread when e.ProgressPercentage is equal to progressBarMaximum, but in our
                                          // example, we just make the code keep running.
                                          // We should cancel bgWorker now because the work is completed and e.ProgressPercentage will
                                          // be greater then the value of the progressBarStatus.Maximum, but if you really want
                                          // you can do something like this to make the thread keep reporting without any errors (until numbers reach the limit)...
                    somethingTerrible++;
                }
                else
                {
                    progressBarStatus.Value++;  // increasing progressBarStatus.Value, until we get to the maximum.
                }
            }
            void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                MessageBox.Show("Worker completed");    // worker finished the task...
            }
    
            // Buttons are added to the Form manually as well
            private void runBgTask_Click(object sender, EventArgs e)    // button on the Form to start the thread
            {
                bgWorker.RunWorkerAsync();  // start the background worker (call DoWork)
            }
    
            private void stopBgTask_Click(object sender, EventArgs e)   // button on the Form to stop the thread
            {
                bgWorker.CancelAsync(); // tell the background worker to stop (will NOT stop the thread immediately); the DoWork will be
                                        // called once again, but with CancelationPending token set to true, so the if statement
                                        // in the DoWork will be true and the thread will stop.
            }
        }
    }
