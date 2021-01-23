        private bool btnClicked;
        private Color btnOrginalColor;
        private void Form1_Load(object sender, EventArgs e)
        {
            btnOrginalColor = button1.BackColor;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (btnClicked)
            {
                button1.BackColor = btnOrginalColor;
                btnClicked = false;
            }
            else
            {
                button1.BackColor = Color.LightBlue;
                btnClicked = true;
            }
        }
