    string Input = Console.ReadLine();
    Decimal InputConvertedAsDecimal;
    if (Decimal.TryParse(Input, out InputConvertedAsDecimal)
    {
        Console.WriteLine("Inputted number is: " + InputConvertedAsDecimal.ToString(CultureInfo.InvariantCulture));
    }
    else
    {
        Console.WriteLine("Error! Input have a incorrect format to parse.");
    }
