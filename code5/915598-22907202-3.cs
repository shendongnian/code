     public MainPage()
    {
       InitializeComponent();
       FillListBox();
    }
     
    private void FillListBox()
    {
       listBox1.ItemsSource = new MovieList();
    }
