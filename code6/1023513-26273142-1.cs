    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace ThreadTest
    {
        public partial class Form1 : Form
        {        
            public Form1()
            {
                InitializeComponent();
                
                WorkerClass worker = new WorkerClass();
                // add event handler
                worker.OnStatusUpdate += new WorkerClass.StatusUpdate(worker_OnStatusUpdate);
                // add UI control to invoke
                worker.UIControl = this;
                worker.Start();
            }
    
            void worker_OnStatusUpdate(DateTime dateTime, string message)
            {
                label1.Text = dateTime.ToLongTimeString();
                label1.Text += " " + message;
            }
    }
