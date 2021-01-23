        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult result = ofd.ShowDialog();
            if(result != DialogResult.Cancel)
            {
                 richTextBox1.Text = File.ReadAllText(ofd.FileName);
            }
        }
