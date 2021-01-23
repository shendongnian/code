    public partial class Form1 : Form
        {
          
           
            public Form1()
            {
                InitializeComponent();
                backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
                backgroundWorker1.RunWorkerAsync();
                backgroundWorker1.DoWork+=new DoWorkEventHandler(backgroundWorker2_DoWork);
                //at this line you get an InvalidOperationException
                backgroundWorker1.RunWorkerAsync();
    
               
               
               
            }
    
            void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
            {
                do
                {
                    
                } while (true);
            }
            void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
            {
                do
                {
    
                } while (true);
            }
           }
