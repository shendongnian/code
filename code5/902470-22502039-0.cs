    public void UpdateItem(ItemViewModel viewModel)
    {
        var item=db.Table.where(x=>x.ID==viewModel.ID).FirstOrDefault();
        item.UpdatedBy = WebSecurity.CurrentUserName;
        item.UpdatedAt = DateTime.Now;
        db.Entry(item).state=EntityState.Modified;
        db.SaveChanges();
    }
