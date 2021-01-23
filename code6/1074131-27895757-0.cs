    for (int i = 1; i <= no_gb; i++)
    {
      GroupBox g1 = new GroupBox();
      g1.Text = "Window " + i;
      g1.Size = new Size(207, 105);
      TextBox txt = new TextBox();
      txt.Name = "txtwidth" + i;
      g1.Controls.Add(txt);//New Line (Code added)
      flowLayoutPanel1.Controls.Add(g1);
    }
