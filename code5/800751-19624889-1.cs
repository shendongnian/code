        private void ReadFromDesktop(string fileName)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullName = System.IO.Path.Combine(desktopPath, fileName);
            using (StreamReader steamReader = new StreamReader(fullName))
            {
                string content = steamReader.ReadToEnd();
            }
        }
