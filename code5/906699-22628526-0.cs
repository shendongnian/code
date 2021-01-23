    string reponse =string.Empty;
    
    private void btntest_Click(object sender, RoutedEventArgs e)
        { 
          var bgw = new BackgroundWorker();
          bgw.DoWork += bw_DoWork;
          bgw.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
          bgw.RunWorkerAsync();
        }
     void async bw_DoWork(object sender, DoWorkEventArgs e)
            {
                try
                {
                  reponse = await sendData();
                }
                catch (Exception ex)
                {
                   
                }
            }
    
     void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
               MessageBox.Show(reponse);
            }
       
