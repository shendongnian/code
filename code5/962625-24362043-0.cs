    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Numpad1)
        {
            button1.performClick();
            textbox.text += button1.text;
            input += button1.text;
        }
        else if (e.KeyCode == Keys.Numpad2)
        {
            button2.performClick();
            textbox.text += button2.text;
            input += button2.text;
        }
        .
        .
        .
        //rest of the code to handle other numpad keys
    }
