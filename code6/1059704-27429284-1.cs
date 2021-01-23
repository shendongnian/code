    public class CalculationMethods
    {
    	public delegate void CalculationDelegate(Detail method);
    	
    	private Dictionary<string, CalculationDelegate> _methods;
    	
    	public CalculationMethods
    	{
    		this._methods = new Dictionary<string, CalculationDelegate>()
    		{
    			{ "Discount", CalculateDiscount },
    			{ "Tax", 	  CalculateTax      }
    		};
    	}
    	
    	public void Calculate(string method, Detail obj_detail)
    	{
    		foreach (Order order in ordersList)
    		{
    			foreach (Detail obj_detail in order.Details)
    			{
    				var m = this._methods.FirstOrDefault(item => item.Key == method).Value;
    				m(obj_detail);
    			}
    		}
    	}
    }
