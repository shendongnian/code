            int iFilesWithPassword = 0;
            Factory.Initialize();
            Application wordApplication = new NetOffice.WordApi.Application();
            try
            {
                // Attempt to open existing document. If document is not password protected then 
                // passwordDocument parameter is simply ignored. If document is password protected
                // then an error is thrown and caught by the catch clause the follows, unless 
                // password is equal to "#$nonsense@!"!                              
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
