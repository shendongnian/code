    var csv = "Mark,2014-09-15 14:31:43 \nJohn,2014-09-15 14:38:29 \nKennedy,2014-09-15 13:49:13 \nJolly,2014-09-15 13:49:18 \nDiana,2014-09-15 13:49:22 \nHenry,2014-09-15 14:33:21 \n";
    var csvItems = csv.Split('\n');
    var dictionary = new Dictionary<string, DateTime>();
    foreach (var item in csvItems)
    {
        if (!string.IsNullOrWhiteSpace(item))
        {
            var itemParts = item.Split(',');
            dictionary.Add(itemParts[0], Convert.ToDateTime(itemParts[1]));
        }
    }
