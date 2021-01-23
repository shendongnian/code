    //--Below code to filter list based on from and to Date
    // ---From Date 
            <code>
        	    if (!string.IsNullOrEmpty(fromDate))
        	    {
        	        DemoList = DemoList.FindAll(x => Convert.ToDateTime(x.DemoRegistrationDate).Date >= Convert.ToDateTime(fromDate).Date);
        	    }
        	</code>
    
    // ---To Date 
           <code>
        	    if (!string.IsNullOrEmpty(toDate))
        	    {
        	        DemoList = DemoList.FindAll(x => Convert.ToDateTime(x.DemoRegistrationDate).Date <= Convert.ToDateTime(toDate).Date);
        	    }
        	</code>
