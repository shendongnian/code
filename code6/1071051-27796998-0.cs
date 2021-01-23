      private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        if (e.Error == null)
            { 
               richBox1.Text=ex.Message;
          }else{
              try{
            File.AppendAllText("C:\\Users\\Jamie\\Desktop\\errorloghardware.txt", "Line:278" + Environment.NewLine);
            backgroundWorker1.RunWorkerAsync(txtTerminal.Text);
            File.AppendAllText("C:\\Users\\Jamie\\Desktop\\errorloghardware.txt", "Line:281" + Environment.NewLine);        
              }catch (Exception ex)
             {
               richBox1.Text=ex.Message;
             }
    }
