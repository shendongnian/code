      this._backgroundWorker.RunWorkerCompleted +=
                              new RunWorkerCompletedEventHandler(bw_WorkComplete);
      ....
    void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker _worker = sender as BackgroundWorker;
        if (_worker != null)
        {
            FileInfo existingFile = new FileInfo("C:\\MyExcelFile.xlsx");
            ConsoleApplication2.Program.ExcelData data = ConsoleApplication2.Program.GetExcelData(existingFile, _worker);
    
            e.Result = new JavaScriptSerializer().Serialize(data);
         }
     }
     private void bw_WorkComplete(object sender, RunWorkerCompletedEventArgs e)
     {
        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
        saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
        saveFileDialog1.ShowDialog();
        if (saveFileDialog1.FileName != "")
        {
           string json = e.Result.ToString();
           File.WriteAllText(saveFileDialog1.FileName, json);
        }
    }
