	public abstract class BaseAction
	{
		private Deals _deals;
		public Deals Deals 
		{
			get
			{
				if (_deals == null)
                     // this = BuyAction or SellAction, never BaseAction because it's abstract
					_deals = new Deals(this);
				return _deals;
			}
			set
			{
				_deals = value;
			}
		}
	
	}
	
	public class BuyAction : BaseAction { }
	public class SellAction : BaseAction { }
	
	public class Deals
	{
		private BaseAction _callerAction;
		public Deals(BaseAction caller)
		{
			this._callerAction = caller;
		}
	
		public int GetDealValueByType()
	    {
	        if (this._callerAction is BuyAction)
	        {
	            return 1;
	        }
	        if (this._callerAction is SellAction)
	        {
	            return 2;
	        }
	        return 0;
	    }
	}
	
	public static void Main(string[] args)
	{
		BaseAction action = new BuyAction();
	    int dealValue = action.Deals.GetDealValueByType();
	    // Prints 1
	    Console.WriteLine(dealValue);
	
	    action = new SellAction();
	    dealValue = action.Deals.GetDealValueByType();
	    // Prints 2
	    Console.WriteLine(dealValue);
    }
