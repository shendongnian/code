    JArray array = JArray.Parse(json);
    List<DateUnique> list = new List<DateUnique>(array.Count - 1);
    for (int i = 1; i < array.Count; i++)
    {
        list.Add(new DateUnique
        {
            date = DateTime.ParseExact(array[i][0].ToString(), 
                "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
            uniques = int.Parse(array[i][1].ToString())
        });
    }
