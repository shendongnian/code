    public MainWindow()
    {
    	InitializeComponent();
    
    	Dictio = new CustomDictionary();
    	Dictio.Add(0, textBox1, TextBox.TextProperty);
    	Dictio.Add(1, textBox2, TextBox.TextProperty);
    	Dictio.Add(2, radioButton, RadioButton.IsCheckedProperty );
    
    	this.DataContext = this;
    }
