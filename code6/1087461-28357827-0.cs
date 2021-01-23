    //Method Add Component (can be any)
    Button button = new Button() { Location = new Point(12, 12) };
    tabControl1.SelectedTab.Controls.Add(button);
    
    //Method Remove Component (Can be any too)
    var controls = tabControl1.SelectedTab.Controls.Cast<Control>().Where(x => x.GetType() == typeof(Button)).ToList();
    
    foreach (var item in controls)
    {
        tabControl1.SelectedTab.Controls.Remove(item);
    }
