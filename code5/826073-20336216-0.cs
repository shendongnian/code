    Match m = System.Text.RegularExpressions.Regex.Match(CityNames, CheckName, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
    
    if (m.Success) {
      MessageBox.Show("String Found: " + m.Value);
    } else {
      MessageBox.Show("String Not Found");
    }
