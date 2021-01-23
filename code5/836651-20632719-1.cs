        private void btnAppendText_Click(object sender, EventArgs e)
        {
            txtText.Text = string.Empty;
            DateTime startTime = DateTime.Now;
            for (int i = 0; i < 10000; i++)
            {
                txtText.AppendText(s);
            }
            DateTime endTime = DateTime.Now;
            txtTime.Text = (endTime.Ticks - startTime.Ticks).ToString();
        }
        private void btnConcante_Click(object sender, EventArgs e)
        {
            txtText.Text = string.Empty;
            DateTime startTime = DateTime.Now;
            for (int i = 0; i < 5000; i++)
            {
                txtText.Text += s;
            }
            DateTime endTime = DateTime.Now;
            txtTime.Text = (endTime.Ticks - startTime.Ticks).ToString();
        }
