    List<string> files = new List<string>();
            int charIndex = 0;
            int numericIndex = -1;
            foreach (var file in files.Select(path => new FileInfo(path)))
            {
                // Create new Filename - This may needs some tuning 
                // to really remove only the extension ad the end
                // It doesnt take care of things like
                // file.bmp.bmp.bmp ...
                string newFileName =  String.Format("{0}_{1}{2}.{3}", 
                    file.FullName.Replace(file.Extension,String.Empty),
                    (char)(charIndex++ + 97), 
                    (numericIndex > -1 ? String.Format("{0:D4}", numericIndex) : String.Empty), 
                    file.Extension);
                // Rename the File
                file.MoveTo(newFileName);
                
                // Increment Counters.
                if (charIndex >= 25)
                {
                    charIndex = 0;
                    numericIndex++;
                }
            }
