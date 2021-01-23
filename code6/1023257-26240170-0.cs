            int iFilesWithPassword = 0;
            Factory.Initialize();
            Application wordApplication = new NetOffice.WordApi.Application();
            try
            {
                // attempt to open existing document. if document is not password protected then 
                // passwordDocument parameter is simply ignored                            
                Document newDocument = wordApplication.Documents.Open(@"C:\Users\Giorgos\Desktop\myNextFile.doc",
                                                                      confirmConversions: false,
                                                                      addToRecentFiles: false,
                                                                      readOnly: false,
                                                                      passwordDocument: "#$nonsense@!");
                // read text of document
                string text = newDocument.Content.Text;
            }
            catch(Exception e)
            {
                Exception inner = e.InnerException;
                if (inner != null && inner.InnerException != null)
                {
                    inner = inner.InnerException;
                    string sErrorMessage = inner.Message;
                    if (sErrorMessage.Contains("The password is incorrect."))
                    {
                        iFilesWithPassword++;
                    }
                }
            }
            finally
            {
                // close word and dispose reference 
                wordApplication.Quit();
                wordApplication.Dispose();
            }
