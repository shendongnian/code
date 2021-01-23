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
                                int angka = Convert.ToInt32(angkaString) + 1;
                                string angka00 = "00" + angka.ToString();
                                tempFolder = FolderName + angka00.Substring(angka00.Length - 3);
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
