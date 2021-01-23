            using (FileStream fileStream = File.Open(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
            {
                using (StreamReader rd = new StreamReader(fileStream))
                {
                    using (StreamWriter wr = new StreamWriter(fileStream))
                    {
                        string line = null;
                        while ((line = rd.ReadLine()) != null)
                        {
                            if (String.Compare(line, active_user) == 0)
                            {
                                //do nothing
                            }
                            else
                            {
                                wr.WriteLine(active_user);
                            }
                        }
                    }
                }                 
            }
