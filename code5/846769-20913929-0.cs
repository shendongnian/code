    public BookDetail()
    {
    	InitializeComponent();
    	List<GenrePicker> newpicker = new List<GenrePicker>();
    	newpicker.Add(new GenrePicker() { Genre = "Comedy",Index = 0});
    	newpicker.Add(new GenrePicker() { Genre = "Science", Index = 1 });
    	newpicker.Add(new GenrePicker() { Genre = "Action", Index = 2});
    	this.ListPicker.ItemsSource = newpicker;
    	this.DataContext = App.MainViewModel;
    }
