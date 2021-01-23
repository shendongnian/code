    public class Agency
	{
		public int Id {get; set;}
		public int ParentId {get; set;}
		public string Name {get; set;}
	}
	
	void Main()
	{
		var list = new List<Agency> {
			new Agency { Id = 7, ParentId = 2},
			new Agency { Id = 8, ParentId = 0},
			new Agency { Id = 9, ParentId = 1},
			new Agency { Id = 6, ParentId = 0},
			new Agency { Id = 1, ParentId = 7},
			new Agency { Id = 2, ParentId = 0},
			new Agency { Id = 3, ParentId = 1},
			new Agency { Id = 4, ParentId = 2},
			new Agency { Id = 5, ParentId = 9}		
		};
		
		Func<Agency,int, bool> isParent = null;
		isParent = (a,i) =>  a != null && 
           (a.Id == i || isParent(list.FirstOrDefault(x => x.Id == a.ParentId),i)); 
		var descendantsOf7 = list.Where(x=>isParent(x,7)).ToList();
	}
