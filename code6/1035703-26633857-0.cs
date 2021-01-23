    for(int i = 0; i < Math.Min(labelNames.Items.Count, textboxNames.Items.Count); i++)
    {
      Label lbl = new Label();
      lbl.Name = "lbl_" + i;
      lbl.Text = textboxNames.Items[i];
      lbl.AutoSize = true;
      Form1.Controls.Add(lbl);
    
      TextBox tbx = new TextBox();
      tbx.Name = "txt_" + i;
      tbx.AutoSize = true;
      Form1.Controls.Add(tbx);
    }
