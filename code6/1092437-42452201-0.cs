    if (System.IO.File.Exists(File.FullName))
                        {
                            try
                            {
                                System.IO.File.Delete(File.FullName);
                            }
                            catch (Exception ex)
                            {
                                throw (new Exception(string.Format("Error overwriting file {0}", File.FullName), ex));
                            }
                        }
    
                        _package.Save(_stream);
                        _package.Close();
                        if (Stream is MemoryStream)
                        {
                            var fi = new FileStream(File.FullName, FileMode.Create);
                            //EncryptPackage
                            if (Encryption.IsEncrypted)
                            {
    #if !MONO
                                byte[] file = ((MemoryStream)Stream).ToArray();
                                EncryptedPackageHandler eph = new EncryptedPackageHandler();
                                var ms = eph.EncryptPackage(file, Encryption);
    
                                fi.Write(ms.GetBuffer(), 0, (int)ms.Length);
    #endif
    #if MONO
                                throw new NotSupportedException("Encryption is not supported under Mono.");
    #endif
                            }
                            else
                            {                            
                                fi.Write(((MemoryStream)Stream).GetBuffer(), 0, (int)Stream.Length);
                            }
                            fi.Close();
                        }
                        else
                        {
                            System.IO.File.WriteAllBytes(File.FullName, GetAsByteArray(false));
                        }
