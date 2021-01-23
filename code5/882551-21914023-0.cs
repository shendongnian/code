    public MainWindow()
    {
    	Dictio = new Dictionary<int, object>();
    	for (int i = 0; i < 200; i++)
    	{
    		Dictio.Add(i, new object());
    	}
    	InitializeComponent();
    	this.DataContext = this;
    }
    <StackPanel>
    	<TextBox Text="{Binding Dictio[0], Mode=OneWayToSource}"/>
    	<TextBox Text="{Binding Dictio[1], Mode=OneWayToSource}"/>
    </StackPanel>
