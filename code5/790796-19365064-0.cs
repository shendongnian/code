    public bool EncryptUsingStream(string inputFileName, string outputFileName)
            {
                bool success = false;
    
                // here assuming that you already have key
                byte[] key = new byte[128];
    
                SymmetricAlgorithm algorithm = SymmetricAlgorithm.Create();
                algorithm.Key = key;
    
                using (ICryptoTransform transform = algorithm.CreateEncryptor())
                {
                    CryptoStream cs = null;
                    FileStream fsEncrypted = null;
                    try
                    {
                        using (FileStream fsInput = new FileStream(inputFileName, FileMode.Open, FileAccess.Read))
                        {
                            //First write IV 
                            fsEncrypted = new FileStream(outputFileName, FileMode.Create, FileAccess.Write);
                            fsEncrypted.Write(algorithm.IV, 0, algorithm.IV.Length);
    
                            //then write using stream
                            cs = new CryptoStream(fsEncrypted, transform, CryptoStreamMode.Write);
                            int bytesRead;
                            int _bufferSize = 1048576; //buggersize = 1mb; 
                            byte[] buffer = new byte[_bufferSize];
                            do
                            {
                                bytesRead = fsInput.Read(buffer, 0, _bufferSize);
                                cs.Write(buffer, 0, bytesRead);
                            } while (bytesRead > 0);
    
                            success = true;
    
                        }
                    }
                    catch (Exception ex)
                    {
                        //handle exception or throw.
                    }
                    finally
                    {
                        if (cs != null)
                        {                       
                            cs.Close();
                            ((IDisposable)cs).Dispose();                    
    
                            if (fsEncrypted != null)
                            {
                                fsEncrypted.Close();
                            }
                        }
    
                    }
                }
                return success;
            }
