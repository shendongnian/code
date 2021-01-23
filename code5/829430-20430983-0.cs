    private List<item> itemlist = new List<item>();
    private void readfromfile()
    {
        var lines = System.IO.File.ReadAllLines("path");
        foreach (string item in lines)
        {
            var values = item.Split(',');
            itemlist.Add(new item()
            {
                stallnumber = long.Parse(values[0]),
                stocknumber = long.Parse(values[1]),
                itemdescription = values[2],
                //and so on
            });
        }
    }
