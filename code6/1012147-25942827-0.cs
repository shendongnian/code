    using(var trans = new TransactionScope(.., ..Serializable..)) {
        var user = _Db.Users.ById(userId);
        user.LolCats.Add( new LolCat() );
        user.LolCatCount = user.LolCats.Count();
        _Db.SaveChanges();
        trans.Complete();
    }
