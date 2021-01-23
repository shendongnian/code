    public void UpdateItem(ItemViewModel viewModel)
    {
        item.UpdatedBy = WebSecurity.CurrentUserName;
        item.UpdatedAt = DateTime.Now;
        db.SaveChanges();
    }
