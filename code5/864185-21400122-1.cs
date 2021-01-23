    public partial class Home : Form
    {
     public class AsynchronousSocketListener : IDisposable
     {
       private BackgroundWorker worker = new System.ComponentModel.BackgroundWorker();
    	 
       private Label myLabel;
       public AsynchronousSocketListener(Label lbl)
       {
           myLabel = lbl;
           worker.RunWorkerCompleted += WorkerCompleted;
           worker.DoWork += DoWork;
           worker.RunWorkerAsync();
       }
       public void Dispose()
        {
            worker.RunWorkerCompleted -= WorkerCompleted;
            worker.CancelAsync();
            worker.Dispose();
        }
    			 
       private void DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
       {
         // Perform your work on the other Thread
         e.Result = currantRFID;
       }
    			 
       public void WorkerCompleted(object sender, RunWorkerCompletedEventArgs args)
       {
          //Here I want to Update a labels text this waw :
          myLabel.Text = args.Result;
       }
             }
    }
    
    
    
    
    /*
    
        public partial class Home : Form
         {
             public class AsynchronousSocketListener
             {
                 private Label myLabel;
                 public AsynchronousSocketListener(Label lbl)
                 {
                    myLabel = lbl;
                 }
                 public void ReadCallback(IAsyncResult ar)
                 {
                   //Here I want to Update a labels text this waw :
                   myLabel.Text = currantRFID;
                 }
             }
         }
    
    */
