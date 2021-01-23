    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
    	public partial class Form1 : Form
    	{
            // this is the UI thread
    		public Form1()
    		{
    			InitializeComponent();
    			Load += new EventHandler(Form1_Load);
    		}
    
    		private BackgroundWorker worker;
            // this is the UI thread
    		void Form1_Load(object sender, EventArgs e)
    		{
    			worker = new BackgroundWorker();
    			worker.DoWork += new DoWorkEventHandler(worker_DoWork);
    			worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
                worker.RunWorkerAsync();
    		}
            // this is the UI thread, the BackgroundWorker did the marshalling for you (Control.Invoke or Control.BeginInvoke)    
    		void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    		{
    			pictureBox1.Image = (Image) e.UserState;
    		}
            // this is a background thread, don't touch the controls on this thread we use .ReportProgress (offered by the backgroundWorker) to marshal back to the UI thread.
    		void worker_DoWork(object sender, DoWorkEventArgs e)
    		{
    			while (iNeedToKeepRotatingImages)
    			{
    				Thread.Sleep(5000);
    				var image = LoadAnImage(myState);
    				worker.ReportProgress(0, image);
    			}
    		}
    	}
        }
        
