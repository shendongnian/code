        public void ReadtxtFile()
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            List<string> IdList = new List<string>;
            List<string> NameList = new List<string>;
            openFileDialog1.InitialDirectory = "c:\\Users\\Person\\Desktop";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (StreamReader sr = new StreamReader(openFileDialog1.OpenFile()))
                        {
                            string line;
                            // Read and display lines from the file until the end of  
                            // the file is reached. 
                            while ((line = sr.ReadLine()) != null)
                            {
                                tbResults.Text = tbResults.Text + line + Environment.NewLine;
                                int SpaceIndex = line.IndexOf("");
                                string Id = line.Substring(0, SpaceIndex);
                                string Name = line.Substring(SpaceIndex + 1, line.Length - SpaceIndex);
                               IdList.Add(Id);
                                NameList.Add(Name);
                            }
                           WriteXmlDocument(IdList, NameList);
                        }
                        myStream.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
        private void WriteXmlDocument(List<string> IdList, List<string> NameList)
            {
    //Do XML Writing here
                }
            }
