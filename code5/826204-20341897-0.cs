    private DateTime _expiryTime;
    
    public void InputTextbox_KeyDown(object sender, KeyEventArgs e)
       {
          if (e.KeyCode == Keys.Enter && InputTextbox.Text.Contains("penny"))
             {
                _expiryTime = DateTime.Now.AddMinutes(1);
                OutputTextbox.Text = "yes sir";
             }
    else if (e.KeyCode == Keys.Enter && InputTextbox.Text.Contains("what time is it") && DateTime.Now < _expiryTime)
       {
    code runs here...
       }
