    using (var context = new ApplicationContext())
    {
           context.UserInfo.AddObject(userInfo); // Here you Go....       
           context.SaveChanges();
    }
