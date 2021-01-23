    for (int i = 1; i <= no_gb; i++)
    {
        GroupBox g1 = new GroupBox();
        g1.Text = "Window " + i;
        g1.Size = new Size(207, 105);
        g1.Name = "gbG1";
        TextBox txt = new TextBox();
        txt.Name = "txtwidth" + i;
        g1.Controls.add(txt);
        flowLayoutPanel1.Controls.Add(g1);
    }
    for (int i = 1; i <= Hlk_WidthArray.Length; i++)
    {
        Hlk_WidthArray[i] += Hlk_WidthArray[i];
        ((TextBox)(((GroupBox)flowLayoutPanel1.Controls["gbG1"]).Controls["txtwidth" + i])).Text = Hlk_WidthArray[i].ToString();
    }
