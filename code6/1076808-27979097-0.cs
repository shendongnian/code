    Control[] ArrControls = this.Controls.Find("radioButtonTimer"+buttonID+"_CountDown");
    if(ArrControls.Where(c => (c as RadioButton).Checked).ToList().Count > 0)
    {
      ... Checked Radio Buttons
    }
    else
    {
      ...
    }
