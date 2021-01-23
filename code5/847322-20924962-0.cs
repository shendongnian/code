    public int getActiveItemsCount(ItemStatus status)
    {
        using (ItemsDBEntities context = new ItemsDBEntities())
        {
            return context.Items.Where(item => item.StatusID == (int)status).Count();
        }
    }
