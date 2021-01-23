    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            EnterButton_Click(null,null);//this is a button event,it fire when you press Enter key
        }
        else if (e.KeyCode == Keys.Back)
        {
            BackSpaceButton_Click(null,null);//this is a button event,it fire when you press Back key
        }
    }
