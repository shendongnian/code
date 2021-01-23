     public static async Task ExtractToDirectory(string strSourcePath, string strDestFolderPath,
            IProgress<int> progessReporter)
        {
            await Task.Factory.StartNew(() =>
            {
                using (ZipArchive archive = new ZipArchive(File.Open(strSourcePath, FileMode.Open)))
                {
                    double zipEntriesExtracted = 0;
                    double zipEntries;
                    zipEntries = archive.Entries.Count;
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        try
                        {
                            string fullPath = Path.Combine(strDestFolderPath, entry.FullName);
                            if (String.IsNullOrEmpty(entry.Name))
                            {
                                Directory.CreateDirectory(fullPath);
                            }
                            else
                            {
                                var destFileName = Path.Combine(strDestFolderPath, entry.FullName);
                                using (var fileStream = File.Create(destFileName))
                                {
                                    using (var entryStream = entry.Open())
                                    {
                                        entryStream.CopyTo(fileStream);
                                    }
                                }
                            }
                            zipEntriesExtracted++;
                            progessReporter.Report((int)((zipEntriesExtracted / zipEntries) * 100));
                        }
                        catch (Exception ex)
                        {
                               
                        }
                    }
                }
                
            }, TaskCreationOptions.LongRunning);
        }
