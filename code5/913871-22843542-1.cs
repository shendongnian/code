    public MyCollection OrderedByPrice(SortOrder sortOrder)
    {
         if (sortOrder == SortOrder.Ascending)
         {
             return new MyCollection(this.OrderBy(x => x.Price));
         }
         else
         {
             return new MyCollection(this.OrderByDescending(x => x.Price));
         }
    }
