    var adLines = new List<string>();
    var bcLines = new List<string>();
    var unknownLines = new List<string>();
    var adList = new[]{"A", "D"};
    var bcList = new[]{"B", "C"};
    using(var debtors = new StreamReader(@"C:\CSV\Debtors.csv"))
    {
        string line = null;
        while((line = debtors.ReadLine()) != null)
        {
            string[] columns = line.Split(';'); // you should check if columns.Length is correct
            string lastColumn = columns.Last();
            if(adList.Contains(lastColumn, StringComparer.CurrentCultureIgnoreCase))
                adLines.Add(line);
            else if(bcList.Contains(lastColumn, StringComparer.CurrentCultureIgnoreCase))
                bcLines.Add(line);
            else
                unknownLines.Add(line);
        }
    }
    File.WriteAllLines(@"C:\CSV\DebtorsSystemen.csv", adLines);
    File.WriteAllLines(@"C:\CSV\DebtorsHolding.csv", bcLines); 
