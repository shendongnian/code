                foreach (int n in arrMessageid)
                {
                    int n2 = n;
                    thrdSendEmail = new Thread(() =>
                    {
                            try
                            {
                                string amazonMessageID = SendSimpleEmail_Part2(messageAmazonRequestBatch.ElementAt(n2).req);
                                messageAmazonRequestBatch.ElementAt(n2).msg.AmazonMessageID = amazonMessageID;
                                logManager_MessageLogwithAmazonmsgID.LogMessage(",\t" + n2 , true);
                                //logManager_MessageLogwithAmazonmsgID.LogMessage(",\t" + n2 + ",\t" + messageAmazonRequestBatch.ElementAt(n2).msg.QueueMessageId + ",\t" + amazonMessageID, true);
                            }
                            catch (Exception ex) { logManager_RunSummary.LogMessage(ex.Message, true); }                                
                    });
     ...
