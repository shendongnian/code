    var orderedList = listOfItems
        .OrderByDescending(item => {
            if (item.Name.Length < 15)
                return DateTime.MinValue;
    
            var datePart = item.Name.Substring(item.Name.Length - 15, 10);
            DateTime date;
            if (!DateTime.TryParse(datePart, out date))
                return DateTime.MinValue;
    
            return date;
        })
        .ToList();
