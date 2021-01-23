    public void NewFolder()
            {
                try
                {
                    string FolderName = Path.Combine(txtOutputFileEn.Text, txtNamaFile.Text);
                    tempFolder = FolderName;
                    if (!Directory.Exists(tempFolder))
                    {
                        Directory.CreateDirectory(tempFolder);
                    }
                    else if (Directory.Exists(tempFolder))
                    {
                        tempFolder = tempFolder + ("001");
                        if (!Directory.Exists(tempFolder))
                        {
                            Directory.CreateDirectory(tempFolder);
                        }
                        else if (Directory.Exists(tempFolder)) 
                        {
                            int x = 1;
                            for (x = 0; x < 50; x++)
                            {
                                string angkaString = tempFolder.Substring(tempFolder.Length - 3);
                                int angka = Convert.ToInt32(angkaString) + x;
                               // formatting the string for 3 digits
                                string angka00 =angka.ToString("D3");                                 
                                 tempFolder = FolderName + angka00;
                                 if (!Directory.Exists(tempFolder))
                                    {
                                        Directory.CreateDirectory(tempFolder);
                                        return;
                                    }
                                }
                            }
                        }
                        MessageBox.Show(tempFolder);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show(this, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
