    string str = Console.ReadLine();
    
    str = Regex.Replace(
            str,
            @"\d+",
            m => (Double.Parse(m.Groups[0].Value) + 1).ToString().PadLeft(m.Groups[0].Value.Length, '0')
            );
