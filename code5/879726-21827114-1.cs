    BindingList<Tool> tools = new BindingList<Tool>();
    private void YourForm_Load(object sender, EventArgs e)
    {
        comboBoxTools.DisplayMember = "Name"; // set display member
        comboBoxTools.DataSource = tools; // bind tools to comboBox
    }
    private void buttonAdd_Click(object sender, RoutedEventArgs e)
    {
        // ... create tool 
        
        // that will add tool both to tools list and comboBox
        tools.Add(tool);
    }
    private void buttonRemove_Click(object sender, RoutedEventArgs e)
    {
        Tool tool = comboBoxTools.SelectedItem as Tool;
        if(tool == null)
           return;
 
        // that will remove tool both from tools list and comboBox
        tools.Remove(tool);
    }   
 
