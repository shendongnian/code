    private List<RadioButton> radioButtons = new List<RadioButton>();
    //Populate this with radios interested, then call HookUpEvents and that should work
    
    private void HookUpEvents()
    {
        foreach(var radio in radioButtons)
        {
            radio.CheckedChanged -= PerformMutualExclusion;
            radio.CheckedChanged += PerformMutualExclusion;
        }
    }
    
    private void PerformMutualExclusion(object sender, EventArgs e)
    {
        Radio senderRadio = (RadioButton)sender;
        if(!senderRadio.Checked)
        {
            return;
        }
        foreach(var radio in radioButtons)
        {
            if(radio == sender || !radio.Checked)
            {
                continue;
            }
            radio.Checked = false;
        }
    }
