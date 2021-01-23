        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(SpreadSheet.Changed)
            {
                switch(MessageBox.Show("Would you like to save your changes?", "Spreadsheet Utility",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
                {
                    case DialogResult.Yes:
                        SaveFileOperation();
                        return;
                    case DialogResult.No:
                        return;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        return;
                }
            }
        }
