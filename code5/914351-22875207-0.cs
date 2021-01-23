                List<string> files = new List<string>();
                if (file1 != null && file2 != null)
                {
                    files.Add(file1);
                    files.Add(file2);
                }
                if (file3 != null)
                {
                    files.Add(file3);
                }
                if (file4 != null)
                {
                    files.Add(file4);
                }
                        max = files.Count;
                        MessageBox.Show("Merge Started");
                        using (Stream output = File.OpenWrite(dest))
                        {
                            foreach (string inputFile in files)
                            {
                                using (Stream input = File.OpenRead(inputFile))
                                {
                                    byte[] buffer = new byte[32 * 1024];
                                    int read;
                                    while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                                    {
                                        output.Write(buffer, 0, read);
                                        count++;
                                        // report progress back
                                        progress = count * 100 / read;
                                        backgroundWorker2.ReportProgress(Convert.ToInt32(progress));
                                    }
                                }
                            }
                        }
                        MessageBox.Show("Merge Complete");
