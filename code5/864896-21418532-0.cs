    try
    {
          
         Parallel.ForEach(arrMessageid.Distinct,
             n => 
             {
                 try
                 {
                     var amazonMessageID = SendSimpleEmail_Part2(messageAmazonRequestBatch.ElementAt(n).req);
                     messageAmazonRequestBatch.ElementAt(n).msg.AmazonMessageID = amazonMessageID;
                     logManager_MessageLogwithAmazonmsgID.LogMessage(",\t" + n , true);
                 }
                 catch (Exception ex)
                 {
                     logManager_RunSummary.LogMessage(ex.Message, true); 
                 }
             }
          );              
                     
    }
    catch (Exception ex)
    {
        logManager_RunSummary.LogMessage(ex.Message, true);
    }
