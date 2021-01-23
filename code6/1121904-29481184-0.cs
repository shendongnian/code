    public YourWindow()
    {
       InitializeComponent();
       this.Loaded += Window_Loaded;
       this.Datacontext = viewmodel // if you'r going with MVVM
    }
    public void Window_Loaded(object sender, RoutedEventArgs e)
    {
       Combobox_cmb.ItemsSource = ((Viewmodel)this.DataContext).Names; //Names should be in your viewmodel if you're going with MVVM. If not just use DataContext as this codebehind and place the list here.
    }
