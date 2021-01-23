    void Main()
    {
    	var members = new List<Member>();
    
    	members.Add(new Member() {NameId = 1, Name = "Hank", IsActive = false, DisplayOrder = 3});
    	members.Add(new Member() {NameId = 2, Name = "Walter", IsActive = true, DisplayOrder = 2});
    	members.Add(new Member() {NameId = 3, Name = "Jimmy", IsActive = true, DisplayOrder = 1});
    	members.Add(new Member() {NameId = 4, Name = "Bell", IsActive = false, DisplayOrder = 4});
    
    	var myDropDownMembers = members.Where(m => m.IsActive == true).OrderBy(m => m.DisplayOrder);
    
    	Console.WriteLine(myDropDownMembers);
    
    }
    
    class Member
    {
    	public Member() {}
    
    	public int NameId;
    	public string Name;
    	public bool IsActive;
    	public int DisplayOrder;
    }
