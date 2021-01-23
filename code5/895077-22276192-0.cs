    var myTableValues = myTable.Descendants("td");
    foreach (var tdV in myTableValues)
    {
        PlayerFile.WriteLine(tdV.InnerText);
        Console.WriteLine(tdV.InnerText);
    }
