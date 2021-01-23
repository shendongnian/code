    var myTableRows = myTable.Descendants("tr").Where(tr => tr.Attributes.Contains("id"));
    foreach (var tr in myTableRows)
    {
        string line = string.Join(";", tr.Descendants("td").Select(td => td.InnerText));
        PlayerFile.WriteLine(line);
        Console.WriteLine(line);
    }
