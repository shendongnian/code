    var query = collListItem.OfType<ListItem>()
            .Select(item => new
            {
                Manager = (FieldUserValue)item["Manger"],
                Amount = item["Amount"] as double?,
            })
            .GroupBy(item => item.Manager.LookupValue)
            .Select(group => new
            {
                Manager = group.Key,
                Amount = group.Sum(item => item.Amount),
            })
            .Select(group => string.Format(
    @"Manager Name: {0} Amount: {1}
    <tr><td class='pdetails'>{0}</td>
    <td class='pdetails'>{1}</td></tr>", group.Manager, group.Amount));
    foreach(var group in query)
        Console.WriteLine(group);
