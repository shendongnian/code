    private void Save() 
    {
        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
        saveFileDialog1.Filter = "Text Document(*.txt)|*.txt|All files(*.*)|";
        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
        {
            using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
            using (StreamWriter sw = new StreamWriter(s))
            {
                sw.Write(textBox1.Text);
            }
        }
    }
    private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) 
    {
        this.Save();
    }
    private void Form1_FormClosing(object sender, FormClosingEventArgs e) 
    {
        DialogResult rezult = MessageBox.Show("Sunteti sigur ca doriti sa iesiti din program !?",
            "Aplication closing", MessageBoxButtons.YesNoCancel);
        if (rezult == DialogResult.Yes)
        {
            this.Save();
            e.Cancel = false;
        }
        else if (rezult == DialogResult.No)
        {
            e.Cancel = false;
        }
        else
            e.Cancel = true;
       }
    }
