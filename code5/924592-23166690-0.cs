    //EncryptFile();
                try
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = "All Files (*.*)|";
                    dialog.InitialDirectory = @"Desktop";
                    dialog.Title = "Please select a file to encrypt.";
    
                    dialog.ShowDialog();
    
                    inputFile = dialog.FileName;
    
                    outputFile = inputFile;
    
                    string password = @"myKey123"; // Your Key Here
                    UnicodeEncoding UE = new UnicodeEncoding();
                    byte[] key = UE.GetBytes(password);
    
                    string cryptFile = outputFile;
                    using (FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create))
                    {
                        RijndaelManaged RMCrypto = new RijndaelManaged();
    
                        using (CryptoStream cs = new CryptoStream(fsCrypt,
                          RMCrypto.CreateEncryptor(key, key),
                          CryptoStreamMode.Write))
                        {
                            using (FileStream fsIn = new FileStream(inputFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                            {
                                int data;
                                while ((data = fsIn.ReadByte()) != -1)
                                    cs.WriteByte((byte)data);
                            }
                        }
    
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
     
