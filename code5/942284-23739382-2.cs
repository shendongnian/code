        private void radioButton_Click(object sender, EventArgs e)
        {
            foreach (TabPage page in tabControl1.TabPages)
            {
                foreach (RadioButton radioButton in page.Controls)
                {
                    if (radioButton != (RadioButton)sender) { radioButton.Checked = false; }
                }
            }
        }
