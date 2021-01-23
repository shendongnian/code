     try
                    {
                        if (fileInfo.Extension.ToLower().Equals(".msg"))
                        {
                            string referenceNumber = "";
                            if (char.IsDigit(fileInfo.Name.First()))
                            {
                                referenceNumber = new string(fileInfo.Name.SkipWhile(c => !char.IsDigit(c)).TakeWhile(char.IsDigit).ToArray());
                            }
                            using (var stream = File.Open(fileInfo.FullName, FileMode.Open, FileAccess.Read))
                            {
                                using (var message = new Storage.Message(stream))
                                {
                                    foreach (Storage.Attachment attachment in message.Attachments.OfType<Storage.Attachment>())
                                    {
                                        
                                        if (attachment.IsInline)
                                            continue; //no need to uncompress inline attqach
                                        
                                        string opFilename = (referenceNumber.Trim().Length > 0) ? string.Format("{0}\\{1}_{2}", fileInfo.Directory.FullName, referenceNumber, attachment.FileName) : string.Format("{0}\\{1}_{2}", fileInfo.Directory.FullName, RandomString(3), attachment.FileName);
                                        File.WriteAllBytes(opFilename, attachment.Data);
                                    }
                                }
                            }
                            
                        }
                    }
                    catch (Exception ex)
                    {
                        _log.ErrorFormat("{0} Unable to convert  msg file: {1}.", fileInfo.Name, ex.Message);
                    }
