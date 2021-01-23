    public class myItem
    {
       public int id { get; set;}
       public String Name { get; set;}
    }
    
    void Main()
    {
    	//My original List
    	List<myItem> masterList = new List<myItem>() { new myItem{ id = 1, Name = "item 1"},
    											new myItem{id = 2, Name = "item 2"},
    											new myItem{id = 3, Name = "item 3"},
    											new myItem{id = 4, Name = "item 4"}
    											};
    	
    	//List of ids of items I want to KEEP in my original list
    	List<int> keepList = new List<int>() {2,3};	
    	
    	// what you want
    	masterList = masterList.Where(i => keepList.Contains(i.id)).ToList();
    }
