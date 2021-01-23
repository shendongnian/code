    public override string ToString()
    {
        Console.WriteLine(System.Globalization.CultureInfo.CurrentCulture);
        Console.WriteLine(System.Globalization.CultureInfo.CurrentUICulture);
    
        string s = string.Format("name: {0} , Date: {1}, Salary: {2}, id {3}", name, startDate.ToShortDateString(), salary, id);
        return s;
    }
