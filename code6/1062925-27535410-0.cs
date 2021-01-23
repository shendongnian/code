    using(var trans = Db.OpenTransaction(IsolationLevel.ReadCommitted))
    { 
        Db.Save(user);
        Db.SaveReferences(user,user.HomeAddress);
        Db.SaveReferences(user,user.Orders);
        trans.Commit();
        return Find(user.Id);
    }
