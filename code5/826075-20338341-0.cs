    string CityNames = "N York";
    string CheckName = @"(NY|New York|[^N-Y])";
    
    System.Text.RegularExpressions.Match match = System.Text.RegularExpressions.Regex.Match(CityNames, CheckName, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
    
    if (match.Success)
    {
    	MessageBox.Show("String Found");
    }
    else
    {
    	MessageBox.Show("String Not Found");
    }
