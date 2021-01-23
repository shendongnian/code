    using(MyEntities me = new MyEntities())
    {
        Contact ct = me.Contact.Include("Location").SingleOrDefault(x=>x.User.UserID == WebSecurity.CurrentUserId);
        ct.Titile = "sometitle"; //assignment and saving works
        ct.Location = me.Location.SingleOrDefault(x=>x.Location_ID == 19); //only assignment works
        me.SaveChanges();
    }
