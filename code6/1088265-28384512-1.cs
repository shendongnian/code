	var colorMapping = new Dictionary<string, string>
    {
		{ "darkblue", "Administrator"},
		{ "green", "B"},
		// ...
    };
    var key = inputcolor[0];
    string output;
    if (colorMapping.TryGetValue(key, out output))
    {
    	dataGridView2.Rows.Add(loggedname1[0], output, mu + loggedprofile1[0]);
    }
