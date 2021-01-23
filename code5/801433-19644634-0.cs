        public void ToggleTextBox()
        {
            textBox1.Visible = radioButton3.Checked;
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ToggleTextBox();
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ToggleTextBox();
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            ToggleTextBox();
        }
