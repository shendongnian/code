	void WriteList()
	{
		// save in invariant culture
		string[] createText = {gespaard.ToString(CultureInfo.CurrentCulture)};
		File.WriteAllLines(path, createText);
	}
	void ReadList()
	{
		string[] readText = File.ReadAllLines(path);
		// read from invariant culture
		bool parsed = double.TryParse(readText[0], NumberStyles.Any, CultureInfo.InvariantCulture, out vorigGespaard);
		if ( !parsed )
			throw new InvalidOperationException("Unable to parse " + readText[0] + " as a double");
        // use the current culture to display the string
		vorigeBedragBox.Text = vorigGespaard.ToString();
	}
	private void berekenButton_Click(object sender, RoutedEventArgs e)
	{
		vorigeBedragBox.Text = vorigGespaard.ToString();
		// get the value from its representation in the current culture
		gespaard = double.Parse(ingaveBox.Text) + vorigGespaard;
        
        // use the current culture to display the string
		gespaardBox.Text = gespaard.ToString();
		WriteList();
		ReadList();
	}
