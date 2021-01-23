    class Set
    { 
        public virtual long Id { get; private set; }
        public virtual IList<SetComponent> Components { get; private set; }
    }
    class SetComponent 
    { 
        public virtual Article Article { get; set; }
        public virtual int Amount { get; set; }
    }
    
    public SetMap()
    { 
        Table("Sets");
        Id(x => x.Id, "SetId");
        // not pretty but has to be there to only return 1 row per id
        Where("ArticleID = (SELECT MIN(s.ArticleID) FROM Sets s WHERE s.SetId == SetId)");
    
        HasMany(x => x.Components)
            .Table("Sets")
            .KeyColumn("SetId")
            .Component(c =>
            {
                c.Reference(x => x.Article, "ArticleID");
                c.Map(x => x.Amount, "Count");
            });
    }
