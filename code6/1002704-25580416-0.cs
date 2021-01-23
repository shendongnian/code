        private bool recognitionRunning;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey && !recognitionRunning)
            {
                label1.BackColor = Color.Green;
                label1.Text = "Speak";
                RecEngine.RecognizeAsync(RecognizeMode.Multiple);
                e.SuppressKeyPress = true;
                recognitionRunning = true;
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                label1.BackColor = Color.Yellow;
                label1.Text = "Ready";
                RecEngine.RecognizeAsyncStop();
                e.SuppressKeyPress = true;
                
                recognitionRunning = false;
            }
        }
