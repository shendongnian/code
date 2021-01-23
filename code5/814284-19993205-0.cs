    void Main()
    {
	User u = UserFactory.Get("f");
	u.Print();
    }
    public class User
    {
    public string FirstName { get; set; }
	
	public virtual void Print()
	{
		Response.Write(this.FirstName);
	}
    }
    public class E : User
    {
    public string MiddleInitial { get; set; }
	
	public override void Print()
	{
		Response.Write(this.FirstName);
	}
    }
    public class F : User
    {
    public string LastName { get; set; }
	
	public override void Print()
	{
		Response.Write(this.LastName);
	}
    }
