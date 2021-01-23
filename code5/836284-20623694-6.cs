    public virtual IEnumerable<Dog> Retrieve()
    {
        var _query = context.Dog.Include(a => a.Owner);
        ...
        ...// rest of your code
    }
