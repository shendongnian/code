    IsolatedStorageFile myIsolatedStorage =   IsolatedStorageFile.GetUserStoreForApplication();
            XmlSerializer serializer = new XmlSerializer(typeof(MyClass));
            XDocument document =    XDocument.Load(myIsolatedStorage.OpenFile("Selections.xml", FileMode.Open));
            MyClass enclaves = (MyClass)serializer.Deserialize(document.CreateReader());
            foreach (var xe in document.Descendants("couplink"))
            {
                mane = xe.Value.ToString();
                WebClient webClient = new WebClient();
                Uri uri = new Uri(mane, UriKind.RelativeOrAbsolute);
                webClient.OpenReadCompleted += new OpenReadCompletedEventHandler(webClient_OpenReadCompleted);
                webClient.OpenReadAsync((uri),mane);
            }
        }
        void webClient_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            int count;
            Stream stream = e.Result;
            byte[] buffer = new byte[1024];
            String imgName = (string)e.UserState;
            String cleanImgName = System.IO.Path.GetFileName(imgName);
            using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (System.IO.IsolatedStorage.IsolatedStorageFileStream isfs = new IsolatedStorageFileStream(cleanImgName, FileMode.Create, isf))
                {
                    count = 0;
                    while (0 < (count = stream.Read(buffer, 0, buffer.Length)))
                    {
                        isfs.Write(buffer, 0, count);
                    }
                    stream.Close();
                    isfs.Close();
                }
            }
