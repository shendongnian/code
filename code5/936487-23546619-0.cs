            using (System.IO.Stream stream = System.IO.File.Open(path, System.IO.FileMode.Open))
            {
                using (System.IO.StreamReader rd = new System.IO.StreamReader(stream))
                {
                    using (System.IO.StreamWriter wr = new System.IO.StreamWriter(stream))
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
