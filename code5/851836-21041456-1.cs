        public void NewFolder()
        {
            try
            {
                string folderName = Path.Combine(txtOutputFileEn.Text, txtNamaFile.Text);
                if (!Directory.Exists(folderName))
                {
                    Directory.CreateDirectory(folderName);
                }
                else
                {
                    // Creates 50 folder from 001 up to 050
                    // This works also if we have folders from 001 up 022 allready. It will extend up to 050
                    for (int i = 1; i <= 50; i++)
                    {
                        // formatting the string for 3 digits like 001, 002 and so on.
                        string angka00 = i.ToString("D3");
                        var folderWithNumber = folderName + angka00;
                        if (!Directory.Exists(folderWithNumber))
                        {
                            Directory.CreateDirectory(folderWithNumber);
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(this, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
