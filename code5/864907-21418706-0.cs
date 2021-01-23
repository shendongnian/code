    foreach (int n in arrMessageid)
        {
            int tempN = n;
            thrdSendEmail = new Thread(() =>
            {
                    try
                    {
                        amazonMessageID = SendSimpleEmail_Part2(messageAmazonRequestBatch.ElementAt(tempN ).req);
                        messageAmazonRequestBatch.ElementAt(tempN ).msg.AmazonMessageID = amazonMessageID;
                        logManager_MessageLogwithAmazonmsgID.LogMessage(",\t" + tempN  , true);
                        //logManager_MessageLogwithAmazonmsgID.LogMessage(",\t" + tempN  + ",\t" + messageAmazonRequestBatch.ElementAt(tempN ).msg.QueueMessageId + ",\t" + amazonMessageID, true);
                    }
                    catch (Exception ex) { logManager_RunSummary.LogMessage(ex.Message, true); }                                
            });
            thrdSendEmail.Name = n.ToString();
            lstThread.Add(thrdSendEmail);
            thrdSendEmail.Start();
            //logManager_MessageLogwithAmazonmsgID.LogMessage(",\t" + n, true);
        }
