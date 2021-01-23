        private void richTextBoxDialog_MouseClick(object sender, MouseEventArgs e)
        {
            string filePath = comboBoxFiles.SelectedItem.ToString();
            
            if (e.Button == MouseButtons.Left)
            {
                int clickIndex = richTextBoxDialog.GetCharIndexFromPosition(e.Location);
                int index = GetIndexInFile(filePath, richTextBoxDialog.Text, clickIndex);
                Point p = GetPositionFromFileIndex(File.ReadAllText(filePath), index);
                OpenNppXY(filePath, p.X, p.Y);
            }
        }
