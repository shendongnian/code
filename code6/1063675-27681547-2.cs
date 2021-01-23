    void Main()
    {
    
    	List<TOrder> orders = new List<TOrder>{
    		new TOrder(1, 1, "Site1"),
    		new TOrder(2, 1, "Site1"),
    		new TOrder(3, 2, "Site2"),
    		new TOrder(4, 2, "Site2"),
    		new TOrder(5, 3, "Site3")
    		};
    
    	List<TOrderEntry> order_entries = new List<TOrderEntry>{
    		new TOrderEntry(1, 1, 5.5),
    		new TOrderEntry(2, 1, 6.2),
    		new TOrderEntry(3, 1, 4.9),
    		new TOrderEntry(4, 1, 55.15),
    		new TOrderEntry(5, 1, 0.97),
    		new TOrderEntry(6, 2, 2.23),
    		new TOrderEntry(7, 2, 95.44),
    		new TOrderEntry(8, 2, 3.88),
    		new TOrderEntry(9, 2, 7.77),
    		new TOrderEntry(10, 3, 25.23),
    		new TOrderEntry(11, 3, 31.13),
    		new TOrderEntry(12, 4, 41.14)
    		};
    		
    //		var qry = from o in orders
    //			select new {
    //				oid = o.ID,
    //				uid = o.UserId,
    //				site = o.Site,
    //				count = order_entries.Where(oe=>oe.OrderId == o.ID).Count(),
    //				cost = order_entries.Where(oe=>oe.OrderId == o.ID).Sum(oe=>oe.Cost)
    //				};
    //		qry.Dump();
    		
    		var qry = (from o in orders join oe in order_entries on o.ID equals oe.OrderId into grp 
    			from g in grp.DefaultIfEmpty()
    			//group g by g into ggg
    			select new{
    				oid = o.ID,
    				uid = o.UserId,
    				site = o.Site,
    				count = grp.Count(),
    				cost = grp.Sum(e=>e.Cost)
    				}).Distinct();
    		qry.Dump();
    }
    
    
    // Define other methods and classes here
    class TOrder
    {
    	private int iid =0;
    	private int uid =0;
    	private string ssite=string.Empty;
    	
    	public TOrder(int _id, int _uid, string _site)
    	{
    		iid = _id;	
    		uid = _uid;
    		ssite = _site;
    	}
    
    	public int ID
    	{
    		get{return iid;}
    		set{iid = value;}
    	}
    
    	public int UserId
    	{
    		get{return uid;}
    		set{uid = value;}
    	}
    
    	public string Site
    	{
    		get{return ssite;}
    		set{ssite = value;}
    	}
    }
    
    
    class TOrderEntry
    {
    	private int iid = 0;
    	private int oid = 0;
    	private double dcost = .0;
    	
    	public TOrderEntry(int _iid, int _oid, double _cost)
    	{
    		iid = _iid;
    		oid = _oid;
    		dcost = _cost;
    	}
    
    	public int EntryId
    	{
    		get{return iid;}
    		set{iid = value;}
    	}
    	
    	public int OrderId
    	{
    		get{return oid;}
    		set{oid = value;}
    	}
    
    	public double Cost
    	{
    		get{return dcost;}
    		set{dcost = value;}
    	}
    
    }
