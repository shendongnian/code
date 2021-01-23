    public Func<int, object> PaginationLinkData
    {
    	get
    	{
    		return index =>
    			{
    				dynamic obj = new ExpandoObject();
    				obj.page = index;
    				obj.amount = this.Amount;
    				if (this.Sort != null)
    				{
    					obj.sort = this.Sort;
    				}
    				if (this.Order != null)
    				{
    					obj.order = this.Order;
    				}
    				return obj;
    			};
    	}
    }
