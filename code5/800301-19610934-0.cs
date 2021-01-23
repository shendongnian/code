    var input = Console.ReadLine();
    var number = !string.IsNullOrWhiteSpace(input) ? input : "0";
    
    var numeralExpression = new System.Text.RegularExpressions.Regex(@"^(\d|-\d)$");
    
    if (numeralExpression.IsMatch(number))
    {
        invoer = int.Parse(number);
    }
