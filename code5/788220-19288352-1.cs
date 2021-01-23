    var number = int.Parse(new string(someString.Where(char.IsDigit).ToArray()));
    if(number<10)
    {
       someList.Add(number);
    }
