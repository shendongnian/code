    private List<Activity> activities;
    public void ActivityDisplay()
    {
        activities = Activity.LoadActivities();
    }
    public ObservableCollection<string> ActivityFilter = new ObservableCollection<string>();
    private void FilterActivities()
    {
        listBox1.ItemsSource = activities.Where(activity => ActivityFilter.Any(filter => filter == activity.Type) || ActivityFilter.Count == 0);
    }
    public PivotPage1()
    {
        InitializeComponent();
        ActivityFilter.CollectionChanged += ActivityFilter_CollectionChanged;
        ActivityDisplay();
    }
    void ActivityFilter_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        FilterActivities();
    }
    private void CookingCheck_Checked(object sender, RoutedEventArgs e)
    {
        ActivityFilter.Add("Cooking");
    }
    private void CookingCheck_Unchecked(object sender, RoutedEventArgs e)
    {
        ActivityFilter.Remove("Cooking");
    }
    //Repeat the procedure for each checkbox
