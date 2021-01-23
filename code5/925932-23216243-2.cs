        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Confirmation._askUserAgain = false;
        }
        private void Yes_Click(object sender, EventArgs e)
        {
            Confirmation._yes = true;
            Confirmation._no = false;
            Form1 parentForm = Application.OpenForms["Form1"] as Form1;
            if (parentForm != null)
            {
                parentForm.Hide();
            }
            this.Hide();
        }
        private void No_Click(object sender, EventArgs e)
        {
            Confirmation._no = true;
            Confirmation._yes = false; 
            if (Confirmation._no)
            {
                this.Hide();
                Form1 parentForm = Application.OpenForms["Form1"] as Form1;
                parentForm.Show();
            }
        }
