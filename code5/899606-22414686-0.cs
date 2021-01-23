    public class BusinessObject1
    {
        public int Id
        {
            get;
            set;
        }
    }
    public class BusinessObject1Collection : KeyedCollection<int, BusinessObject1>
    {
        protected override int GetKeyForItem(BusinessObject1 item)
        {
            return item.Id;
        }
    }
    public class BusinessObject2
    {
        public string Id
        {
            get;
            set;
        }
    }
    public class BusinessObject2Collection : KeyedCollection<string, BusinessObject2>
    {
        protected override string GetKeyForItem(BusinessObject2 item)
        {
            return item.Id;
        }
    }
