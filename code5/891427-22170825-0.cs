    protected void Page_Load(object sender, EventArgs e)
    {
        HideRadioButtonLists(Page.Controls);
    }
    
    private void HideRadioButtonLists(ControlCollection controls)
    {
        foreach (WebControl control in controls.OfType<WebControl>())
        {
            if (control is RadioButtonList)
                control.Visible = false;
            else if (control.HasControls())
                HideRadioButtonLists(control.Controls);
        }
    }
