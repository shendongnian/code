    public virtual ICollection<EntityPairString> StringExpando
    {
        get
        {
            var values = ((IEnumerable<EntityPair<string, object>>)Properties)
                .Where(c => c.Value is string)
                .Select(d => new EntityPairString()
                {
                    Key = d.Key,
                    Value = d.Value as string,
                    Id = d.Id,
                    FK = Id,
                    TableName = TableName
                }).ToList();
            return values;
        }
        set
        {
            if (Properties == null) Properties = new PropertyBag();
            foreach (var i in value)
            {
                var p = (EntityPair<string, string>)i;
                Properties.Add(new EntityPair<string, object>
                {
                    Id = i.Id,
                    Key = i.Key,
                    Value = i.Value,
                    FK = Id,
                    TableName = TableName
                });
            }
        }
    }
