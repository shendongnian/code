    public class MyController()
    {
    	...
    	
    	public ActionResult Foo()
    	{
    		...
    		using (var transaction = new TransactionScope())
    		{
    			this.myUserService.CreateUser(...);
    			this.myCustomerService.CreateOrder(...);
    			
    			transaction.Commit();
    		}
    	}
    }
