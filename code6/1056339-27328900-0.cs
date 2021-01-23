    public ImageMap()
    {
        ...
        HasManyToMany(f => f.Tags)
           .Table("ImageTags")
           .LazyLoad()
           .Inverse()         // WRONG, remove this
           .Cascade.SaveUpdate(); 
    }
