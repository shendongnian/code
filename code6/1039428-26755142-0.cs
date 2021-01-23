        public void Search()
        {
            DateTime minimiumDate;
            DateTime maximumDate;
            foreach (string file in Directory.GetFiles(path))
            {
                DateTime fileDate = DateTime.Parse(file);
                if(fileDate > minimiumDate && maximumDate > fileDate)
                    //dostuff
            }
        }
