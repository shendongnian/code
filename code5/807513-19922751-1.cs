    private void bw_DoWork(object sender, DoWorkEventArgs e)
     {
                BackgroundWorker worker = sender as BackgroundWorker;
           
    
      while ((len = objReader.BaseStream.Read(buffer, 0, buffer.Length)) != 0)
                            {
                               .....
    
                              .......
                                int iProgressPercentage = (int)(dProgressPercentage * 100);
                                bw.ReportProgress(iProgressPercentage);
    
                            }
    }
