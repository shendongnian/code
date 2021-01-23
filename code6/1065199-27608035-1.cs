    foreach (GroubBox g in Control.OfType<GroupBox>())
    {
        foreach (TextBox a in g.Controls.OfType<TextBox>())
        {
           a.Text = "";
        }
    }
