    public class DTOItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OrderId { get; set; }
    }
    
      //Elsewhere do "Mapper.CreateMap<Item, DTOItem>();"
    
    public List<DTOItem> GetItems(IQueryable<Item> itemQuey, Expression<Func<DTOItem, bool>> predicate)
    {
        itemQuery.Project().To<DTOItem>().Where(predicate).ToList();
    }
