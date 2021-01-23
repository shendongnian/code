            string sourceFile = @"c:\finaltest12.csv";
            if (!File.Exists(sourceFile))
                return;
            string Todaysdate = DateTime.Now.ToString("dd-MMM-yyyy");
            string newPath = Path.Combine(@"c:\test\final test\snaps\", Todaysdate);
            if (!Directory.Exists(newPath))
                Directory.CreateDirectory(newPath);
            try
            {
                File.Move(sourceFile, Path.Combine(newPath, Path.GetFileName(sourceFile)));
            }
            catch
            {
                //ToDo
            }
