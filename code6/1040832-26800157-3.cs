    d = Regex.Replace(d, "([0-9]{0,})", (m) =>
    {
        int i;
        if (int.TryParse(m.Value, out i))
        {
            return (2*i).ToString();
        }
        return m.Value;
    }, RegexOptions.None);
    Console.WriteLine(d);
