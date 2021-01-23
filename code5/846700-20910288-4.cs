    public static IEnumerable<Items> getData()
    {
        List<Items> itemsList = new List<Items>();
        try
        {
            using (ItemsDBEntities context = new ItemsDBEntities())
            {
                itemsList = (from item in context.Items
                             select new Items()
                             {
                                 ID = item.ID,
                                 Code = item.Code,
                                 Name = item.Name,
                                 StatusID = item.StatusID
                             }).ToList();
            }
        }
        catch (EntityException ex)
        {
            throw new ConnectionFailedException(ex);
        }
        return itemsList;
    }
