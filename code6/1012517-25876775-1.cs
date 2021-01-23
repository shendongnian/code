            Form1 with the button
    public void SetVisibility(bool visible)
    {
       Button.Visible = visible;
    }
          Form 2 With CheckBox
    CheckBox_CheckChanged(object sender, EventArgs e)
    {
        Form1.SetVisibility(CheckBox.Checked);
    }
