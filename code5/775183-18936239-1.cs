    using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (storage.FileExists("employees.xml"))
                {
                    //Load it
                }
                else
                {
                    System.Windows.Resources.StreamResourceInfo strm = Application.GetResourceStream(new Uri("/NewApp;component/Sources/employees.xml", UriKind.Relative));
                    System.IO.StreamReader reader = new System.IO.StreamReader(strm.Stream);
                    string data = reader.ReadToEnd();
                    using (var file = storage.OpenFile("employees.xml", System.IO.FileMode.Create))
                    {
                        using (var writer = new System.IO.StreamWriter(file))
                        {
                            writer.WriteLine(data);
                        }
                    }
                }
            }
