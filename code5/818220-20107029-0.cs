	public string Description
	{
		get { return _description; }
		set 
		{
			_description = string.Empty;
			
			var substrings = value.Split( '.' );
			for ( int i = 0; i < substrings.Length; i++ )
			{
				_description += substrings[i];
				if ( i%5 == 0 )
				{
					_description += Environment.NewLine;
				}
			}	
		}
	}
	private string _description = string.Empty;
