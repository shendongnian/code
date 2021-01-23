	private DispatcherTimer timer;
	private int index = 0;
	List<Location> locations = new List<Location>();
	public MainPage()
	{
		InitializeComponent();
		timer = new System.Windows.Threading.DispatcherTimer
		{
			Interval = TimeSpan.FromSeconds(1) // TODO: your interval
		};
		timer.Tick += timer_Tick;
	}
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        locations.Clear();
        for (double x = 0, y = 0; y < 10; x+=0.005, y++)
        {
            locations.Add(new Location(54.958879 + x, -7.733027 + x));
            locations.Add(new Location(54.958879 - x, -7.733027 - x));
        }
        timer.Start();
    }
	void timer_Tick(object sender, EventArgs e)
	{
		var item = locations[index];
		map.SetView(new Geocoordinate(item.Latitude, item.Longitude), 13, MapAnimationKind.Linear);
		if(index >= locations.Count)
			timer.Stop();
		else
			index++;
	}
