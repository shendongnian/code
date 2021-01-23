    var includes = new Expression<Func<Customer, object>>[] 
        { 
            i => i.SubProperty1, 
            i => i.SubProperty2
        };
    var query = db.Entities.AllIncluding(includes);
