                    NetworkCredential Cred = new NetworkCredential(ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"], ConfigurationManager.AppSettings["Domain"]);
                    SecureString PassWord = new SecureString();
                    foreach (char c in ConfigurationManager.AppSettings["Password"].ToCharArray()) PassWord.AppendChar(c);
                    clientContext.Credentials = new SharePointOnlineCredentials(ConfigurationManager.AppSettings["Username"], PassWord);
                    Web web = clientContext.Web;
                    clientContext.Load(web);
