    public List<MyClass> GetList()
        {
            try
            {
                string username = ConfigurationManager.AppSettings["username"];
                string password = ConfigurationManager.AppSettings["password"];
                string url = ConfigurationManager.AppSettings["AccountUrl"];
                var newList = new List<MyClass>();
                var securePassword = new SecureString();
                for (int i = 0; i < password.Length; i++)
                {
                    securePassword.AppendChar(password[i]);
                }
                var creds = new SharePointOnlineCredentials(username, securePassword);
                var clientContext = new ClientContext(url)
                {
                    Credentials = creds
                };
                List announcementsList = clientContext.Web.Lists.GetByTitle("mylist");
                CamlQuery query = CamlQuery.CreateAllItemsQuery();
                var items = announcementsList.GetItems(query);
                clientContext.Load(items);
                clientContext.ExecuteQuery();
                foreach (var col in items)
                {
                    newList.Add(new MyClass()
                    {
                        Id = Convert.ToInt32(col["ID"]),
                        FirstName = (string) col["FN"],
                        LastName = (string) col["LN"],
                        Email = (string) col["EM"],
                        UserId = (string) col["UID"],
                        Password = (string) col["PD"],
                        Title = (string) col["Title"]
                    });
                }
                return newList;
            }
            catch (Exception)
            {
                return null;
            }
          
        }
