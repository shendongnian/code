      Response.ContentEncoding = new UTF8Encoding();
    try
            {
                byte[] PDF;
                WebClient myWebClient = new WebClient();
                //define the credentials
                NetworkCredential networkCredential = new NetworkCredential(ConfigurationManager.AppSettings["ReportServerUser"].ToString(), ConfigurationManager.AppSettings["ReportServerPass"].ToString());
                myWebClient.Credentials = networkCredential;
                string strURL = string.Empty;
    
                strURL = ConfigurationManager.AppSettings["ReportServerURL"].ToString() + "/Pages/Folder.aspx?ItemPath=%2fDev+Reports%2f404a5+Participant+Notice_TD" + "?planid=" + txt404a5.Text + "&rs:Command=Render&rs:Format=PDF";
                HttpWebRequest myWebRequest = (HttpWebRequest)HttpWebRequest.Create(strURL);
                myWebRequest.Credentials = networkCredential;
                myWebRequest.Timeout = 600000;
                HttpWebResponse myWebResponse = (HttpWebResponse)myWebRequest.GetResponse();
                System.IO.Stream myStream = myWebResponse.GetResponseStream();
                byte[] Buffer = new byte[4096];
                int BlockSize = 0;
                System.IO.MemoryStream TempStream = new System.IO.MemoryStream();
                do
                {
                    BlockSize = myStream.Read(Buffer, 0, 4096);
                    if (BlockSize > 0)
                        TempStream.Write(Buffer, 0, BlockSize);
                } while (BlockSize > 0);
                PDF = TempStream.ToArray();
                myWebClient.Dispose();
    
                //Send the report to the browser
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-disposition", "attachment; filename=SummaryOfPlanExpenses.pdf");
    
                Response.ContentEncoding = new UTF8Encoding();
    
                Response.BinaryWrite(PDF);
    
                Response.End();
            }catch (WebException webEx){
                test.Text = webEx.ToString();
            }
