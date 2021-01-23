    public Func<int, object> PaginationLinkData
	    {
	        get
	        {
				if( this.Sort != null ) 
	            {
	            	return index => new
					{
						page = index, // This is the internal pointer part that is used currently by Bootstrap pagination function
						amount = this.Amount,
						sort = this.Sort,
						order = this.Order
					};
	            }
				else
				{
					return index => new
					{
						page = index, // This is the internal pointer part that is used currently by Bootstrap pagination function
						amount = this.Amount,
					};
				}
	        }
	    }
