    public Dictionary<string,IEnumerable<Items>> getDate()
    {
        using (ItemsDBEntities context = new ItemsDBEntities())
        {
            return (from status in context.Status
                    join item in context.Items on status.ID equals item.StatusID into itemsByStatus
                    select new 
                    {
                        StatusName = status.Status,
                        items = itemsByStatus.Select(i=>
                            new Items()
                            {
                                Code = i.Code,
                                Name = i.Name,
                                StatusID = i.StatusID 
                            })
                    }).ToDictionary(e=>e.StatusName, e=>e.items);
        }
    }
