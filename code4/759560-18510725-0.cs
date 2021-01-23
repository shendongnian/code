    public class FindFile
    {
        public static string _fullName;
        public static string FullName
        {
            get 
            {
                if (_fullName == null)
                     throw new FullNameNotInitialized();
                return _fullName;  
            }
            set 
            { 
                _fullName = value; 
            }
        }
        public void sourceFinder()
        {
            string partialName = "APP";
            DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo(@"/");
            FileInfo[] filesInDir = hdDirectoryInWhichToSearch.GetFiles("*" + partialName + "*.*");
            foreach (FileInfo foundFile in filesInDir)
            {
                // Do not use a variable here, use the field
                _fullName = foundFile.FullName;
                System.Diagnostics.Debug.WriteLine(fullName);
            }
            // Use the property...
            MessageBox.Show(FullName);
            // ... or the field
            MessageBox.Show(_fullName);
        }
    }
