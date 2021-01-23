    using(var context = new MyDbContext()){
        context.Entry(myUser).State = EntityState.Modified
        context.Entry(myUser.MyTrusts).State = EntityState.Modified;
        context.SaveChanges();
    }
