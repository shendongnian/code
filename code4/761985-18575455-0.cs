    public static DateTime DateTimeCheck(object objDateTime)
    {
       ...
       return DateTime.ParseExact(objDateTime.ToString(),"dd/MM/yy",CultureInfo.InvariantCulture);    
    }
