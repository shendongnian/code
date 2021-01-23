    public IEnumerable<Tuple<Item,decimal, decimal>> GetAllCurrentItems(Expression<Func<Item, bool>> filterExpression){
        using(MyContext context = new MyContext())
        {
            var items = context.Items
                    .Where(filterExpression)
                    .Select(item => new Tuple<Item,decimal, decimal> ( 
                        item, 
                        item.ItemPrices.Where(x => item.ItemPrices.Max(y => y.EffectiveDate) == x.EffectiveDate),
                        item.ItemReductions.Where(x => x.StartDate <= DateTime.Now && DateTime.Now <= x.EndDate)});
            return items;
        }
    }
