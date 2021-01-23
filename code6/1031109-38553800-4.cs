        private void sendButton_Click(object sender, EventArgs e)
        {
            if(commsEstablished && serialPort1.IsOpen)
            {
                string text = richTextBox1.Text;
                try
                {
                    serialPort1.WriteLine(text);
                }
                catch
                {
                    // Add exception handling here
                }
            }
        }
