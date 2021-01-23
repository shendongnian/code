    public IEnumerable<Control> GetControls(Control control,Type type)
    {
        var controls = control.Controls.Cast<Control>();
        return controls.SelectMany(ctrl => GetControls(ctrl,type)).Concat(controls).Where(c => c.GetType() == type);
    }
    
    private void btnNew_Click(object sender, EventArgs e)
    {
    	SetComboBoxDefaults();
    	SetTextBoxDefaults();
    	SetButtonDefaults();
    }
    
    private void SetComboBoxDefaults()
    {
    	var comboBoxes = GetControls(this, typeof(ComboBox));
    	foreach (var comboBox in comboBoxes)
    	{
    	    ((ComboBox)comboBox).Enabled = false;
            ((ComboBox)comboBox).Text = null;
    	}
    }
    
    private void SetTextBoxDefaults()
    {
    	var textBoxes = GetControls(this, typeof(TextBox));
    	foreach (var textBox in textBoxes)
    	{
    	    ((TextBox)textBox).Clear();
    	}
    }
    
    private void SetButtonDefaults()
    {
    	var buttons = GetControls(this, typeof(Button));
    	foreach (var button in buttons)
    	{
    	    ((Button)button).Visible = false;
    
    	    if (button.Name == "btnSave") ((Button)button).Text = "&Save";
    	}
    }
