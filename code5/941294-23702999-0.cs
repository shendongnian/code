        private void Popup_Load(object sender, EventArgs e)
        {
            messageLabel.Text = TextToShow;
            Graphics gfx = this.CreateGraphics();
            SizeF textSize = gfx.MeasureString(messageLabel.Text, messageLabel.Font);
            Size borders = this.Size - this.ClientSize;
            this.Size = new Size((int)textSize.Width, (int)textSize.Height) + borders;            
        }
