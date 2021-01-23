    [WebMethod]
    public Item[] GetMyItems()
    {
        List<Item> listOfItems= new List<Item>();
        Item add = new Item();
        using (var db = new Baza()) // into in my database (this works fine)
        {
            var lookUp = from a in db.listOfItems
                         select new
                         {
                             ID = a.ID,
                             Name = a.name,
                             Year= a.year,
                             Price= a.price
                         };
            foreach (var item in lookUp )
            {
                if (item.Name == "Usb")
                {
                    add.name = item.Name;
                    add.year = item.Year;
                    add.price = item.Price;
                    listOfItems.Add(add);
                }
            }
            return listOfItems.ToArray();
        }
    }
