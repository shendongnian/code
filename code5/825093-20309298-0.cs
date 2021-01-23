     using (StreamReader sr = File.OpenText(path))
                            {
                                string[] lines = File.ReadAllLines(path);
                                for (int x = 0; x < lines.Length - 1; x++)
                                {
                                    if (lines[x].Contains(domain, StringComparison.InvariantCultureIgnoreCase)
                                    {
                                        sr.Close();
                                        MessageBox.Show("there is a match");
                                    }
                                }
                                if (sr != null)
                                {
                                    sr.Close();
                                    MessageBox.Show("there is no match");
                                }
                            }
