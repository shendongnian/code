    private void StartCreatingReport(DataGrid dgDisplay)
        {
            
            dgDisplay.SelectAllCells();
            dgDisplay.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, dgDisplay);
            String result = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);           
            dgDisplay.UnselectAllCells();
         
            string path = Environment.CurrentDirectory + "\\Reports\\SampleReport.csv";
          
            System.IO.StreamWriter file1 = new System.IO.StreamWriter(@path);
          
            file1.WriteLine(result);
            file1.Close();
        }
