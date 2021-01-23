    while((CONTINUE)&&(!(reader.EOF)))
    {
       if(StillConnected())
       {
          ExtractDataFromStream(reader);
       }
       else
       {
          Reconnect();
       }
    
       //ProgressChanged Event can be used for reading data, saving data, etc.
       BW.ReportProgress(0);
    }
