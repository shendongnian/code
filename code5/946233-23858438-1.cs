    int index = 0;
    button1.Click(object sender, eventargs e)
    {
        index = index + 1;
        button1.enabled = false;
    }
    button2.Click(object sender, eventargs e)
    {
        index = index + 1;
        button2.enabled = false;
    }
    button3.Click(object sender, eventarfs e)
    {
        index = index + 1;
        button3.enabled = false;
    }
    //And now the button to see if all buttons have been clicked:
    button4.Click(object sender, eventargs e)
    {
        if (index == 3)
        {
            Messagebox.Show("All buttons have been clicked.")
        }
        else
        {
            Messagebox.Show("Not all buttons have been clicked")
        }
    }
