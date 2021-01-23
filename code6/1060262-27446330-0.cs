    webView.Loaded += WebBrowser_OnLoaded;
        private void WebBrowser_OnLoaded(object sender, RoutedEventArgs e)
        {
            SaveFilesToIsoStore();
            chatView.Navigate(new Uri("Assets/HtmlContent/index.html", UriKind.Relative));
        }
		
		private void SaveFilesToIsoStore()
        {
            //These files must match what is included in the application package,
            //or BinaryStream.Dispose below will throw an exception.
            string[] files = {
                "Assets/HtmlContent/index.html", 
                "Assets/HtmlContent/js/libs/jquery-1.11.0.min.js",  "Assets/HtmlContent/js/pagejs.js",  "Assets/HtmlContent/css/style.css"
            };
            IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication();
            if (false == isoStore.FileExists(files[0]))
            {
                foreach (string f in files)
                {
                    StreamResourceInfo sr = Application.GetResourceStream(new Uri(f, UriKind.Relative));
                    using (BinaryReader br = new BinaryReader(sr.Stream))
                    {
                        byte[] data = br.ReadBytes((int)sr.Stream.Length);
                        SaveToIsoStore(f, data);
                    }
                }
            }
        }
        private void SaveToIsoStore(string fileName, byte[] data)
        {
            string strBaseDir = string.Empty;
            string delimStr = "/";
            char[] delimiter = delimStr.ToCharArray();
            string[] dirsPath = fileName.Split(delimiter);
            //Get the IsoStore.
            IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication();
            //Re-create the directory structure.
            for (int i = 0; i < dirsPath.Length - 1; i++)
            {
                strBaseDir = System.IO.Path.Combine(strBaseDir, dirsPath[i]);
                isoStore.CreateDirectory(strBaseDir);
            }
            //Remove the existing file.
            if (isoStore.FileExists(fileName))
            {
                isoStore.DeleteFile(fileName);
            }
            //Write the file.
            using (BinaryWriter bw = new BinaryWriter(isoStore.CreateFile(fileName)))
            {
                bw.Write(data);
                bw.Close();
          
