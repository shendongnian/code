      private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EnterButton_Click(null, null); // Or do whatever you want
            }
            else if (e.KeyCode == Keys.Back)
            {
                BackSpaceButton_Click(null, null);  // Or do whatever you want
            }
        }
