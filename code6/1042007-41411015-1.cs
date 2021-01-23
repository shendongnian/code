    private void cmdBold_Click(object sender, EventArgs e)
    {
       Font new1, old1;
       old1 = rtxtBox.SelectionFont;
       if (old1.Bold)
          new1 = new Font(old1, old1.Style & ~FontStyle.Bold);
       else
          new1 = new Font(old1, old1.Style | FontStyle.Bold);
    
       rtxtBox.SelectionFont = new1;
       rtxtBox.Focus();
    }
    private void cmdItalic_Click(object sender, EventArgs e)
    {
      Font new1, old1;
      old1 = rtxtBox.SelectionFont;
      if (old1.Italic)
        new1 = new Font(old1, old1.Style & ~FontStyle.Italic);
      else
        new1 = new Font(old1, old1.Style | FontStyle.Italic);
    
      rtxtBox.SelectionFont = new1;      
    
      rtxtBox.Focus();
    }
    private void cmdUnderline_Click(object sender, EventArgs e)
    {
      Font new1, old1;
      old1 = rtxtBox.SelectionFont;
      if (old1.Underline)
        new1 = new Font(old1, old1.Style & ~FontStyle.Underline);
      else
        new1 = new Font(old1, old1.Style | FontStyle.Underline);
      rtxtBox.SelectionFont = new1;
      rtxtBox.Focus();
    }
