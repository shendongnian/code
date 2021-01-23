        c.Key(k =>
        {
            k.Column("columnName");
            // or...
            k.Column(x =>
            {
                x.Name("columnName");
                // etc.
            });
    
            k.ForeignKey("collection_fk");
            k.NotNullable(true);
            k.OnDelete(OnDeleteAction.NoAction); // or OnDeleteAction.Cascade
            k.PropertyRef(x => x.Name);
            k.Unique(true);
            k.Update(true);
        });
        ....
