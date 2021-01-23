    for(inti i = 0; i < 7; i++)
    {
        Control c = parentControl.Find("TextBoxT" + i);
        if(c != null)
        {
           c.BackColor = getColour(time.moments[i]);
        }
    }
