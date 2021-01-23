    public int getActiveItemsCount(ItemStatus status)
    {
        using (ItemsDBEntities context = new ItemsDBEntities())
        {
            var enumvalue=(int)status;
            return context.Items.Where(item => item.StatusID == enumvalue).Count();
        }
    }
