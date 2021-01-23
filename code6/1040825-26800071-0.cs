    using (var context = new ApplicationContext())
    {
           context.UserInfo.InsertOnSubmit(userInfo); // Here you Go....       
           context.SaveChanges();
    }
