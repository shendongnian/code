            private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Persist application-scope property to isolated storage
            IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForDomain();
            using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("abc.txt", FileMode.Create, storage))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                foreach (var keyValuePair in GetProperties(this))
                {
                    writer.WriteLine("{0},{1}", keyValuePair.Key, keyValuePair.Value);
                }
            }
        }
        private Dictionary<string,string> GetProperties(Window window)
        { 
            return new Dictionary<string,string>{
            {"Left",window.Left.ToString()},
            {"Top",window.Top.ToString()},
            {"Width",window.Width.ToString()},
            {"Height",window.Height.ToString()}
        };
        }
