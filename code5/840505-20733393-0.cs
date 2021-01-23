    private void alphaCode_Click(object sender, EventArgs e)
    {
        char currentChar = alphaCode.Text[0];
        
        if(currentChar == '-')
        {
            alphaCode.Text = "A";
        }
        else
        {
            char newChar = currentChar + 1;
            if(newChar > 'Z')
            {
                newChar = 'A';
            }
            alphaCode.Text = newChar;
        }
    }
