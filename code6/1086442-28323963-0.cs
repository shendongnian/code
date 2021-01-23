    foreach (Textbox t in groupPanel1.Controls.OfType<TextBox>())
    {
    t.MouseClick += new MouseEventHandler(
      delegate(object sender, MouseEventArgs e)
      {
        btnSave.Enabled = true;
      });
    }
