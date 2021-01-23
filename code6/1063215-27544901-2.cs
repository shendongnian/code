    public class Item
    {
        public int Key { get; set; }
    }
    public interface IDataFacade
    {
        Item Get(int p);
    }
    public class BusinessLogic
    {
        private readonly IDataFacade facade;
        public BusinessLogic(IDataFacade facade)
        {
            this.facade = facade;
        }
        public Item Get(int p)
        {
            return this.facade.Get(p);
        }
    }
