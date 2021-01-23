    string input = "291014";
    DateTime inputDate = new DateTime(
        Convert.ToInt32(input.Substring(4, 2)),
        Convert.ToInt32(input.Substring(2, 2)),
        Convert.ToInt32(input.Substring(0, 2)));
    Console.WriteLine(inputDate.Year); // 14, oops
    Console.WriteLine(DateTime.Now.Year); // 2014
