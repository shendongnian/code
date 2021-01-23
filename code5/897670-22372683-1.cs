       private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
       {
           Class1 yeni = new Class1(this);
           yeni.Update();
       }
    
       public  void  UpdateMyProgressBar(int i)
       {
           backgroundWorker1.ReportProgress(i);
       }
