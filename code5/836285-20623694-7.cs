    public virtual IEnumerable<Owner> Retrieve()
    {
        // you can nest as many as you want if there are more nav properties
        var _query = context.Owner
            .Include(a => a.DogList)
            .Include(a => a.CatList); 
        ...
        ...// rest of your code
    }
