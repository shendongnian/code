	private string _title;	
	public Title 
    {
		get
		{
			return _title;
		}
		set
		{
			_title = value;
			UrlTitle = HttpUtility.UrlEncode(value.Replace(" ", "-").Trim());
		}
    }
    public UrlTitle { get; private set; }
