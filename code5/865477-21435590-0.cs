    string str = "1234/xxxxx";
    string[] array = str.Split(new []{'/'}, StringSplitOptions.RemoveEmptyEntries);
    int number = 0;
    if (str.Length == 2 && int.TryParse(array[0], out number))
    {
        //parsing successful. 
    }
    else
    {
        //invalid number / string
    }
    Console.WriteLine(number);
