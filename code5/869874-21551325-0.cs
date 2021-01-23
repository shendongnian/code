    var ready = false;
    var liCount = 0;
    var pDelayBetweenRetry = 500;
    while(!ready)
    {
      try
      {
        myWordDoc.Close(ref doNotSaveChanges, ref oMissing, ref oMissing);
        ready = true;
      }
      catch (System.Runtime.InteropServices.COMException loE)
      {
        liCount++;
        if ((uint)loE.ErrorCode == 0x80010001)                      
        {
          // RPC_E_CALL_REJECTED - sleep half sec then try again
          System.Threading.Thread.Sleep(pDelayBetweenRetry);
        }
      }  
    }
