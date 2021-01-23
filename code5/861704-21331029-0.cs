        public string GetFullSaveName(string pdfName)
        {
            string myDirectoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (myDirectoryName != null)
            {
                string fullSaveName = Path.Combine(myDirectoryName, pdfName);
                return fullSaveName;
            }
            throw new ApplicationException("Unable to locate assembly path");
        }
