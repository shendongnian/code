    public class ReadingSchedule
    {
    	public ReadingSchedule() { }
    	public ReadingSchedule(string date, string chapter)
    	{
    		Date = date;
    		Chapter = chapter;
    	}
	private bool _isToday;
	public bool IsToday
	{
		get { return _isToday; }
		private set { _isToday = value; }
	}
	private string _date;
	public string Date 
	{
		get { return _date; }
		set
		{
			if (Convert.ToDateTime(value).Day == DateTime.Now.Day)
				IsToday = true;
			_date = value;
		}
	}
	public string Chapter { get; set; }
    }
    <DataTemplate>
        <StackPanel x:Name="sp">
            <TextBlock FontSize="20" TextWrapping="Wrap" FontWeight="SemiBold" Text="{Binding Date}"/>
            <TextBlock FontSize="27" TextWrapping="Wrap" Margin="0, 0, 0, 20" Text="{Binding Chapter}"/>
        </StackPanel>
    
        <DataTemplate.Triggers>
            <DataTrigger Binding="{Binding IsToday}" Value="true">
                <Setter TargetName="sp" Property="Background" Value="Red" />
            </DataTrigger>
        </DataTemplate.Triggers>
    </DataTemplate>
