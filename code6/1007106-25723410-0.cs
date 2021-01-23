    void ClearTextBoxes(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                TextBox textBox = child as TextBox;
                if (textBox == null)
                    ClearTextBoxes(child);
                else
                    textBox.Text = string.Empty;
            }
        }
    
        private void resetCurrentPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearTextBoxes(tabControl1.SelectedTab);
        }
