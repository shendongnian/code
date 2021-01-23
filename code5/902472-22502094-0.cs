     var data= db.Items.where(x=>x.ID==viewModel.ID).SingleOrDefault();
        foreach(db.Items in data)
        {
            item.UpdatedBy = WebSecurity.CurrentUserName;
            item.UpdatedAt = DateTime.Now;
        }
         db.SaveChanges();
