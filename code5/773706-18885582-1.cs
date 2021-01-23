    protected void btn_Click(object sender, EventArgs e)
    {
      Button btn = (Button)sender;
      if (fButtonLookup.ContainsKey(btn))
      {
        ButtonInfo info = fButtonLookup[btn];
        // do waht you need with button information
      }
    }
