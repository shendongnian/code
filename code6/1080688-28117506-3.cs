     List<int> intList = new List<int> { 1, 2, 3, 4, 5 };
     List<DateTime> dateList = new List<DateTime> { DateTime.Now, DateTime.Now.AddDays(3), DateTime.Now.AddDays(5) };
    
     var intRange = intList.GetRange ();
     var dateRange = dateList.GetRange ();
