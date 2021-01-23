    class SetComponent 
    { 
        public virtual Set ContainingSet { get; set; }
        public virtual Article Article { get; set; }
        public virtual int Amount { get; set; }
    }
    
    public SetComponentMap()
    { 
        CompositeId()
            .KeyReference(x => x.ContainingSet, "SetID")
            .KeyReference(x => x.Article, "ArticleID");
    
        Map(x => x.Amount, "Count");
    }
    long setId = 5;
    var components = session.Query<SetComponent>().Where(c => c.ContainingSet.Id == setId);
    var set = new Set(setId, components);
