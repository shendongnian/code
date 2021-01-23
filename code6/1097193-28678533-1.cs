    <TabControl Grid.Row="0">
        <TabItem Header="One" IsSelected="{Binding Path=Tab1Selected, Mode=TwoWay}"/>
        <TabItem Header="Two" IsSelected="{Binding Path=Tab2Selected, Mode=TwoWay}"/>
    </TabControl>
    
    private bool tab1Selected = true;
    private bool tab2Selected = false;
    public bool Tab1Selected
    {
        get { return tab1Selected; }
        set
        {
            if (tab1Selected == value) return;
            tab1Selected = value;
            NotifyPropertyChanged("Tab1Selected");
        }
    }
    public bool Tab2Selected
    {
        get { return tab2Selected; }
        set
        {
            if (tab2Selected == value) return;
            tab2Selected = value;
            if (tab2Selected)
            {
                MessageBox.Show("Tab2Selected");
                // do your stuff here
            }
            NotifyPropertyChanged("Tab2Selected");
        }
    }
