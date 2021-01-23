            try
            {
                foreach (var f in files)
                {
                    using (StreamReader sr = new StreamReader(f.file))
                    {
                        string readLine;
                        do
                        {
                            readLine = sr.ReadLine();
                            string[] readLineSplit = readLine.Split('|');
                            if (readLineSplit.Length > 1)
                            {
                                //Make call to database for query and update it with the readSplit.
                            }
                        } while (!sr.EndOfStream);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
