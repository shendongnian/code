        if (button1.Text == "Input First Integer")
        {
            button1.Text = "Input Second Integer";
        }
        else if (button1.Text == "Input Second Integer")
        {
            button1.Text = "Input Third Integer";
        }
        else if (button1.Text == "Input Third Integer")
        {
            button1.Text = "Input First Integer";
            button1.Enabled = false;
        }
