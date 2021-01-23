            private void textBox1_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                 // do your search
                 e.SuppressKeyPress = true; // to avoid annoying BING ! sound.
                }
            }
