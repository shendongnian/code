    using (myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                    {
                        if (!myIsolatedStorage.DirectoryExists("Contact"))
                            myIsolatedStorage.CreateDirectory("Contact");
    
                        using (writeFile = new StreamWriter(new IsolatedStorageFileStream("Contact\\me.txt", FileMode.Create, myIsolatedStorage)))
                        {
                          writeFile.WriteLine(address);
                        }
                    }
    NavigationService.Navigate(new Uri("/Contacts.xaml", UriKind.Relative));
