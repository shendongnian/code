    CONTINUE = true;
    while((CONTINUE)&&(!(reader.EOF)))
    {
       if(StillConnected())
       {
          try
          {
              ExtractDataFromStream(reader);
          }
          catch (Exception ex)
          {
              CONTINUE = False;
              
              //Because we are on a separate thread, we can't update
              //the UI directly.  So we save the error message to a
              //global variable (string.)
              strErrorMessage = "Exception: " + ex.Message +
                                "\n\nStackTrace: " + ex.StackTrace;
          }
       }
       else
       {
          //To prevent infinite stuck loops, i.e. website goes down
          //try a counter
          if (RECONNECTCOUNT <= 1000)
          {
              Reconnect();
              RECONNECTCOUNT++;
          }
          else
          {
              CONTINUE = false;
              RECONNECTCOUNT = 0;
          }
       }
    
       //ProgressChanged Event can be used for reading data, saving data,
       //updating the UI, etc.
       BW.ReportProgress(0);
    }
