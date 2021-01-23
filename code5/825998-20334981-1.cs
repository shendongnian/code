    void Main()
    {
    	List<Business> bList = new List<Business>()
    	{
    	    new Business(1, "Business1"),
    		new Business(2, "Business2"),
    		new Business(3, "Business3"),
    		new Business(4, "Business4"),
    		new Business(5, "Business5"),
    	};
    	
    	var nList = new List<Notification>()
    	{
    	  new Notification(1, "Notification1", 1),
    	  new Notification(2, "Notification2", 1),
    	  new Notification(3, "Notification3", 3),
    	  new Notification(4, "Notification4", 2),
    	  new Notification(5, "Notification5", 2),
    	  new Notification(6, "Notification6", 2),
    	};
    	
    	var JoinedBusiness = from not in nList
                     		 join busi in bList
                 			 on not.BusinessId equals busi.Id 
                  			 select new { Notification = not.Name, Business = busi.Name };
    						 
    	JoinedBusiness.Dump();
    	
    }
    public class Notification
    {
      	public Notification(int id, string name, int businessid)
    	{
    	 this.Id = id; this.Name = name; this.BusinessId = businessid;
    	}
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public int BusinessId { get; set; }
    }
    
    public class Business
    {
    	public Business(int id, string name)
    	{
    	  this.Id = id;
    	  this.Name = name;
    	}
    	public int Id { get; set; }
    	public string Name { get; set; }
    }
