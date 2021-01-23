    public MyCollection OrderedByPriceThenByDate(SortOrder sortOrder)
    {
         if (sortOrder == SortOrder.Ascending)
         {
             return new MyCollection(this.OrderBy(x => x.Price)
                                    .ThenBy(y => y.Date));
         }
         else
         {
             return new MyCollection(this.OrderByDescending(x => x.Price)
                                    .ThenByDescending(y => y.Date));
         }
    }
