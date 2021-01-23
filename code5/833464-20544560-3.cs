    using (OpenFileDialog open = new OpenFileDialog())
            {
                if (open.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader sr = new StreamReader(open.FileName))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (line.Contains("Example"))
                            {
                                MessageBox.Show("Found");
                                break;
                            }
                        }
                    }
                }
            }
