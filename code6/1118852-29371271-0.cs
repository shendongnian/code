    [NotMapped]
    public IEnumerable<FieldImage> NotDeletedImages 
    {
        get 
        {
            return this.Images.Where(x => !x.Deleted);
        }
    }
