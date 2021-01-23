    Tester tester = new Tester();
    
    //Add property to return your Tester instance.
    public Tester TestLink
    {
    	get { return tester; }
    }
    
    //In your XAML bind Test property.
    <TextBox Name="txtTestMessage" Text="{Binding TestLink.Test}" />
