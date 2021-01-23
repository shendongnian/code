    public virtual void CreateBag<TElement>(PropertyInfo prop, Type classType)
    {
        Bag<TElement>(prop.Name,
        collectionMapping =>
        {
            collectionMapping.Table(prop.Name + "_" + classType.Name + "_Rel");
            collectionMapping.Key(k => k.Column(prop.Name + "_Id"));
        },
        mapping => mapping.ManyToMany(p => p.Column(classType.Name + "_Id")))
        ;
    }
