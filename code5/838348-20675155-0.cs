    private Conditions = new Dictionary<string, Expression<Func<YourLinqEntityClass, bool>>>() {
        { "A", /* cond A */ },
        { "B", /* cond B */ },
        { "C", /* cond C */ },
        // (...)
        { "I", /* cond I */ }
    }
    IEnumerable<lst> fnc()
    {
        if(Conditions.ContainsKey(category))
            return db.Entities.Where(Conditions(category));
        return db.Entities;
    }
