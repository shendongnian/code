    public class BaseAction{} 
    public class BuyAction : BaseAction
    {
        public int Value { get{ return 1; }} 
    }
    public class SellAction : BaseAction
    {
        public int Value { get{ return 2; }}
    }
    public class Deals<T> where T : BaseAction,  new() 
    {
        public int GetDealValue()
        {
            var data = new T();
            return data.Value;
        }
    }
