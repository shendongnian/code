    List<JQueryVersion> Data = new List<JQueryVersion>()
	{
		new JQueryVersion("jquery-1.10.2.min.js"),
		new JQueryVersion("jquery-1.11.0.min.js"),
		new JQueryVersion("jquery-1.5.1.min.js"),
		new JQueryVersion("jquery-1.6.1.min.js"),
		new JQueryVersion("jquery-1.6.2.min.js"),	
	};
	
	var Sorted_Data = Data
		.OrderByDescending (d => d.Version_Numeric[0])
		.ThenByDescending (d => d.Version_Numeric[1])
		.ThenByDescending (d => d.Version_Numeric[2]);
