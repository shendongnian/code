    string testCaptured = string.Empty;
    int keyPressed = 0;
    private void User_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (keyPressed < 5)
        {
            testCaptured += e.keyChar;
            keyPressed++;
        }
        else
        {
            textBox.Text = string.Format("You Wrote: - {0}\n", testCaptured);
            textBox.ScrollToCaret();
        }
    } 
