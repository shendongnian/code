    public ObservableCollection<Customer> CustomerList
    {
      get { return (ObservableCollection<Customer>)
    GetValue(CustomerListProperty); }
      set { SetValue(CustomerListProperty, value); }
    }
    // Using a DependencyProperty as the backing store for MyProperty.
    //This enables animation, styling, binding, etc...
    public static readonly DependencyProperty CustomerListProperty =
    DependencyProperty.Register("CustomerList",
    typeof(ObservableCollection<Customer>), typeof(MainPage),
        new PropertyMetadata(new ObservableCollection<Customer>()));
