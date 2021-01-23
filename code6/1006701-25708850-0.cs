        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.mouseX = (int)movetoX.Value;
            Settings.Default.mouseY = (int)movetoY.Value;
            Settings.Default.Save();
        }
