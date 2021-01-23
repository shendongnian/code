     if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                    using (StreamWriter sw = new StreamWriter(s))
                    {
                        sw.Write(textbox1.Text);
                        sw.Write(combobox1.Text);
                        sw.Close();
                        sw.Dispose();
                    }
                    s.Close();
                    s.Dispose();
                }
