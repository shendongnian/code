                    string path = @"C:\YourFileName.udl";
                    if(System.IO.File.Exists(path))
                    {
                        string testfile = string.Empty;
                        try
                        {
                            testfile = File.ReadLines(path).Last();
                        }
                        catch
                        {
                            // File is empty, handle exception
                        }
                        if (testfile != string.Empty)
                        {
                            var finalPath = tempfile.Remove(0, tempfile.IndexOf(';') + 1);
                            ConnectionString = finalPath;
               // Save ConnectionString to your App.config or do something else with it
                    }
                 
