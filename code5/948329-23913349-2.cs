            string myPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            string originalName = "System.Data.SQLite.dll";
            // If we haven't already renamed the right library
            if (!System.IO.File.Exists(string.Format("{0}\\{1}", myPath, originalName)))
            {
                foreach (var file in System.IO.Directory.GetFiles(myPath))
                {
                    string fileName = System.IO.Path.GetFileName(file);
                    if (fileName.StartsWith("System.Data.SQLite."))
                    {
                        // !! Do your platform checks here !!
                        // ..
                        // Copy the file with its original name
                        System.IO.File.Move(file, file.Replace(fileName, "System.Data.SQLite.dll"));
                        // Delete old file (not necessary)
                        System.IO.File.Delete(file);
                    }
                }
            }
            var assembly = Assembly.LoadFile(string.Format("{0}\\{1}", myPath, originalName));
