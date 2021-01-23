     foreach (string s in filePaths)
                    {
                        try
                        {
                            using (FileStream fileStream = new FileStream(s, FileMode.Open, FileAccess.Read))
                            {
                                //Do no thing
                                listFile.Add(s);
                            }
                        }
                        catch
                        {
                          // file can't access, because it is being used by another process(pasteing).
                        }
                    }
