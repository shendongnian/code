    public void DoSomething()
    {
        object selected = this.GetType().GetField("Person", 
            System.Reflection.BindingFlags.NonPublic | 
            System.Reflection.BindingFlags.Static).GetValue(this);
        this.PropertyGrid1.SelectedObject = selected;
    }
    public void Item_Checked(object sender, RoutedEventArgs e)
    {
        DoSomething();
    }
    
