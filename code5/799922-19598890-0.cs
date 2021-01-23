    if (string.IsNullOrWhiteSpace(textBoxNum1.Text) == false)
    {
       MyLottoNumbers = Regex.Matches(textBoxNum1.Text, @"([^\s]+)\s*")
                             .OfType<Match>()
    	                     .Select(mt => int.Parse(mt.Groups[0].Value))
    	                     .ToList();
    }
    else
    {
      MyLottoNumbers = new List<int>(); // Create empty list as to not throw an exception.
    }
