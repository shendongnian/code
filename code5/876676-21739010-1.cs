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
    	    comboBox.Enabled = false;
        	comboBox.Text = null;
    	}
    }
    
    private void SetTextBoxDefaults()
    {
    	var textBoxes = GetControls(this, typeof(TextBox));
    	foreach (var textBox in textBoxes)
    	{
    	    textBox.Clear();
    	}
    }
    
    private void SetButtonDefaults()
    {
    	var buttons = GetControls(this, typeof(Button));
    	foreach (var button in buttons)
    	{
    	    button.Visible = false;
    
    	    if (button.Name == "btnSave") button.Text = "&Save";
    	}
    }
