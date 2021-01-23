     string sPath = @"C:\Users\NET\Desktop\" + TextBox1.Text + ".txt";
                using (StreamWriter SaveFile = new StreamWriter(sPath))
                    for (int a = 0; a < listBox1.Items.Count; a++)
                    {
                        string line = String.Format("{0},{1}", listBox1.Items[a], listBox2.Items[a]);
                        SaveFile.WriteLine(line);
    
                    }
