    public Product
    {
       public string Name {get;set;};
       [ForiegnKey("Category")]
       public CategoryId {get;set;};
       public Category Category {get; set;}
    } 
