    private void button1_Click(object sender, EventArgs e)
    {
        OpenFileDialog buka = new OpenFileDialog();
        buka.InitialDirectory = "";
        buka.Filter = "Text files(*.txt)|*.txt|All files (*.*)|*.*";
        buka.FilterIndex = 2;
        buka.RestoreDirectory = true;
        buka.Title = "Cari";
    
        buka.ShowDialog();
        string bukafile = buka.FileName;
        if (!String.IsNullOrEmpty(bukafile))
        {
            StreamReader isiFile = File.OpenText(bukafile);
            while (isiFile.Peek() != -1)
            {
                string line = isiFile.ReadLine();
                if (!listBox1.Items.Contains(line))
                {
                    listBox1.Items.Add(line);
                }
            }
                isiFile.Close();
        }
    }
