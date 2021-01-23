    public Person()
    {
        this._numbers = new EntitySet<Number>(
        delegate (Number entity)
        {
            entity.Person = this;
        },
        delegate (Number entity)
        {
            entity.Person = null;
        });
    }
