    foreach (string line in File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\ArchivoaSeparar.txt"))
                {
                    String checkItem = cadenaTextBox.Text.ToString();
                    string[] parts = line.Split(checkItem.ToCharArray());
    
                    foreach (string item in parts)
                    {
                        listBox1.Items.Add((line.Contains(checkItem) ? item + checkItem : item));
                    }
                }
