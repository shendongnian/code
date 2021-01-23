    using(Print2Flash3.Server2 obj = new Print2Flash3.Server2())
      {
            Print2Flash3.BatchProcessingOptions 
            batchProcess = new        BatchProcessingOptions();
            batchProcess.BeforePrintingTimeout = 60000;
            batchProcess.AfterPrintingTimeout = 10000;
            batchProcess.PrintingTimeout = 120000;
            batchProcess.ActivityTimeout = 30000;
            batchProcess.KillProcessIfTimeout = ThreeStateFlag.TSF_YES;
            batchProcess.ApplyChanges();
    
            obj.ConvertFile(inputFilename, outputFullPath, null, batchProcess, null);
      }
