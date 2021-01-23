    class Form1
    {
      private System.ComponentModel.BackgroundWorker bgw;
    
      public Form1()
      {
        bgw = new BackgroundWorker();
        bgw.DoWork += WorkMethod;
        bgw.RunWorkerCompleted += WorkCompleteMethod;
      }
    
      private void Button1_Click(object sender, eventargs e)
      {
         if (!bgw.IsBusy)
         {
           bgw.RunWorkerAsync();
         }
      }
    
      private void WorkMethod(object sender, DoWorkEventArgs e)
      {
        //perform work
        //set result to e.Result
      }
    
      private void WorkCompleteMethod(object sender, RunWorkerCompletedEventArgs e)
      {
        //extract result from eventargs
        //update ui
      }
    }
