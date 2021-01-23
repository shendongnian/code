     private void button1_Click(object sender, EventArgs e)
            {
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string strengur = "\";";
                    string[] filePaths = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
                    foreach(var file in filePaths)
                    {
                        var lines = File.ReadAllLines(file);
                        int currentstart = int.Parse(lines[31].Split(';')[1].Trim('\"'));
                        lines[31] = "\"Treatment!!\";\"" + (currentstart+100).ToString() + strengur;
                        File.WriteAllLines(file, lines);
                    }
                }
            }
