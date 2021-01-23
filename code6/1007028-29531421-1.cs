    /// <summary>
    /// Clone a replica of this item in the database
    /// </summary>
    /// <returns>The cloned item</returns>
    public Item CloneDeep()
    {
        using (var context = new EntityObjectContext())
        {
            var item = context.Items
                .Where(i => i.ItemID == this.ItemID)
                .Single();
            context.Detach(item);
            item.EntityKey = null;
            item.ItemID = 0;
            return item;
        }
    }
