    var number = "1112223333";
    //an alternative method using regexes
    var regexFormat = Regex.Replace(number, @"^(\d{3})(\d{3})(\d{4})$", "($1)$2-$3");
    
    //The methods you provided
    string formattedNumber = String.Format("{0}{1}{2}", number.Substring(0, 3), number.Substring(3, 3), number.Substring(6, 4));
    string formattedNumber1 = String.Format("({0}){1}-{2}", number.Substring(0, 3), number.Substring(3, 3), number.Substring(6, 4));
