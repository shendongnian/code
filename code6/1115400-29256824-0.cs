        private void Btn_Click(object sender, EventArgs e)
        {
            convertingFrom = (sender as Button).Text.Substring(0, 3);
            CCDisplay.Text = "Converting to: " + convertingFrom;
        }
