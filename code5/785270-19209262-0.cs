    Control DelCon(string Name)
    {
        Control toRemove;
        foreach (Control c in panel1.Controls)
        {
             if (c.Name == Name)
             {
                toRemove = c;
                break;
             }
        }
        if(toRemove != null)
            panel1.Controls.Remove(toRemove); 
        return null;
    }
