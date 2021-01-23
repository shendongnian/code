    using(var context = new MyDbContext()){
        context.Entry(myUser).State = EntityState.Added
        context.Entry(myUser.MyTrusts).State = EntityState.Modified;
        context.Entry(myUser.MyTrusts).Property(x => x.MyTrustName).IsModified = false;
        context.Entry(myUser.MyTrusts).Property(x => x.Region).IsModified = false;
        context.Entry(myUser.MyTrusts).Property(x => x.DoNotUse).IsModified = false;
        context.SaveChanges();
    }
