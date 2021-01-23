        // Make delegate and event
        public delegate void DisplayData(string aMessage);
        public event DisplayData ShowData;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Call event
            ShowData(txtMessage.Text);
        }
  
