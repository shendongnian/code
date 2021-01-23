        public string Text
        {
            get
            {
                return txtTextBox.Text.ToString();
            }
            set
            {
                txtTextBox.Text = HttpUtility.HtmlDecode(value);
            }
        }
