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
