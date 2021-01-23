    var str = "product|11111111|name|2006-10-09|code1|code2|product|22222222|name|2006-10-09|code1|code2|product|33333333|name|2011-02-03|code1|code2";
    var delimiter = "|";
    var sb = new StringBuilder();
    // using a list for the List<T>.GetRange() method (see below)
    var splitString = str.Split(new [] { delimiter }, StringSplitOptions.None).ToList(); 
    var index = 0;
    var numValues = 6;
    while (index + numValues <= splitString.Count)
    {
        sb.AppendLine(String.Join(delimiter, splitString.GetRange(index, numValues)));
        index += numValues;
    }
    Console.WriteLine(sb.ToString());
    /* 
       Output:
         product|11111111|name|2006-10-09|code1|code2
         product|22222222|name|2006-10-09|code1|code2
         product|33333333|name|2011-02-03|code1|code2
    */
