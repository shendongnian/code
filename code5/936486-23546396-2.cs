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
                                //If you flush what you write then you will see it via the reader.
                                //Comment out for better performance. Keep in mind, that writing
                                //into a file will lead to occasional flush which affects the
                                //reader. Implicit Flush happens once you write more than the
                                //buffer of the writer suggests.
                                wr.Flush();
                            }
                        }
                    }
                }                 
            }
