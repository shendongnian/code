                foreach (ITestAttachment attachment in thisTestRun.Attachments)
                {
                    if (attachment.AttachmentType == AttachmentTypes.TrxTmiTestRunSummary)
                    {
                        WebRequest request = HttpWebRequest.Create(attachment.Uri);
                        request.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
                        WebResponse response = request.GetResponse();
                        using (System.IO.Stream responseStream = response.GetResponseStream())
                        {
                            System.IO.StreamReader reader = new System.IO.StreamReader(responseStream);
                            trxFile.Load(reader);
                        }
                        break;
                    }
                }
