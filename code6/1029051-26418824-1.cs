    public delegate void UpdateTextBoxValue(string value);
    private UpdateTextBoxValue _updateTextBoxValue;
    
    public New(UpdateTextBoxValue updateTextBoxValue)
    {
    	InitializeComponent();
    
    	_updateTextBoxValue = updateTextBoxValue;
    }
    
    private void ListBox1_SelectedIndexChanged(System.Object sender, System.EventArgs e)
    {
    	_updateTextBoxValue.Invoke(ListBox1.SelectedItem.ToString);
    }
