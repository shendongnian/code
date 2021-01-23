    public Book TheBook { get; set; }
    public Form1()
    {
        InitializeComponent();
        TheBook = new Book("");
        textBox1.DataBindings.Add(new Binding("Text", TheBook, "Name", true, DataSourceUpdateMode.OnPropertyChanged, ""));
    }
