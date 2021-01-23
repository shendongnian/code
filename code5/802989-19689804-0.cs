    ToolTip buttonToolTip = new ToolTip();
    
    private void optionsvalueComboBox_MouseHover(object sender, EventArgs e)
    {
        buttonToolTip.ToolTipTitle = "Value";
        buttonToolTip.UseFading = true;
        buttonToolTip.UseAnimation = true;
        buttonToolTip.IsBalloon = true;
        buttonToolTip.ShowAlways = true;
        buttonToolTip.AutoPopDelay = 5000;
        buttonToolTip.InitialDelay = 1000;
        buttonToolTip.ReshowDelay = 0;
    
        buttonToolTip.SetToolTip(optionsvalueComboBox, optionsvalueComboBox.Text);
      }
