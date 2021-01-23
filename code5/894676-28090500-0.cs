        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.FileName = "new_doc.txt";
            s.Filter = "Text File | *.txt";
            if (s.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(s.FileName))
                {
                    foreach (string line in richTextBox1.Lines)
                    {
                        sw.WriteLine(line);
                    }
                }
            }
        }
