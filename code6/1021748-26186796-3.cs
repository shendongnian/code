    long tempNumber = number;
    List<long> splitNumbers = new List<long>();
    while (tempNumber > 0)
    {
       long currentDigits = number % 10000;
       tempNumber = tempNumber / 10000; //Make sure this is integer division!
    
       //Store cuurentDigits off in your variables
       // 8888 would be the first number returned in this loop
       // then 1111 and so on
       splitNumbers.Add(currentDigits);
    }
    //We got the numbers backwards, so reverse the list
    IEnumerable<long> finalNumberList = splitNumbers.Reverse();
