    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;
    
    [Binding]
    public class SalesOrderSteps
    {
    	[Given("I have already created a Sales Order")]
    	public void GivenIHaveAlreadyCreatedASalesOrder()
    	{
    		var order = new SalesOrder()
    		{
    			// .. set default properties
    		};
    
            // Save to scenario context so subsequent steps can access it
            ScenarioContext.Current.Set<SalesOrder>(order);
    		using (var db = new DatabaseContext())
    		{
    			db.SalesOrders.Add(order);
    			db.SaveChanges();
    		}
    	}
    
    	[Given("I have already created a Sales Order with the following attributes:")]
    	public void GivenIHaveAlreadyCreatedASalesOrderWithTheFollowingAttributes(Table table)
    	{
    		var order = table.CreateInstance<SalesOrder>();
        
            // Save to scenario context so subsequent steps can access it
            ScenarioContext.Current.Set<SalesOrder>(order);
    		using (var db = new DatabaseContext())
    		{
    			db.SalesOrders.Add(order);
    			db.SaveChanges();
    		}
    	}
    }
