    if (PhoneApplicationService.Current.State.ContainsKey("name"))
    {
        string name = (string)PhoneApplicationService.Current.State["name"];
        names.Add(name);
        InitializeComponent();
        List.ItemsSource = names;
    }
    else
    {
        // Whatever
    }
