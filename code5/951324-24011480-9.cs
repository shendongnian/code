    public IGridBuilder<TModel> WithColumns(Action<IColumnBuilderFactory<TModel>> bindAllColumns)
    {
        var factory = new ColumnBuilderFactory<TModel>(this);
        bindAllColumns(factory);
    
        foreach(var column in factory)
        {
            this.ColumnBuilders.Add(column );
        }        
        return this;
    }
