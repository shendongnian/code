    private void MouseHover(object sender, EventArgs e)
    {
        Button oButton = (Button)sender;
        if (oButton.Name == "button1")
        {
            oButton.Cursor = Cursors.WaitCursor;
        }
        else if (oButton.Name == "button2")
        {
            oButton.Cursor = Cursors.Hand;
        }
        else if (oButton.Name == "button3")
        {
            oButton.Cursor = Cursors.Default;
        }
    }
