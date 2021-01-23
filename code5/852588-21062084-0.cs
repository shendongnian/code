            try
            {
		
               // files from sourcefolder
                string[] files = System.IO.Directory.GetFiles(sourceFolder);
		// subfolder from sourcefolder
                string[] folders = Directory.GetDirectories(sourceFolder);
                
                foreach (string file in files)
                {
                    string name = Path.GetFileName(file);
                    string dest = Path.Combine(desFolder, name);
                    File.Copy(file, dest);
                }
               
                foreach (string folder in folders)
                {
                    string name = Path.GetFileName(folder);
                    string dest = Path.Combine(desFolder, name);
                   
                    if (!Directory.Exists(dest))
                        Directory.CreateDirectory(dest);
                   
                    string[] subfiles = System.IO.Directory.GetFiles(folder);
                    foreach (string subfile in subfiles)
                    {
                        string subname = Path.GetFileName(subfile);
                        string subdest = Path.Combine(dest, subname);
                        File.Copy(subfile, subdest);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
