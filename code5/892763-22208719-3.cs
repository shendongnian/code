    //build list of random dates
    Random r = new Random();
    var dates = new List<DateTime>();
    for (int i = 0; i < 10; i++)
    {
        dates.Add(new DateTime(2014, r.Next(1,13), r.Next(1,28)));
    }
    //sort list (if you don't do this, you'll most likely get the wrong answer)
    dates.Sort();
 
    //get input
    string input = "1/13/14";
    DateTime inputDate = DateTime.Parse(input);
 	
    //find nearest
    var result = dates.BinarySearch(inputDate);
    DateTime nearest;
    nearest = (result >= 0) ? dates[result] : dates[~result];
