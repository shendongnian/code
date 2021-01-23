    void Main()
    {
    	var userMock = new Mock<User>();
    	userMock.As<IUser>().Setup(w => w.UserId).Returns(1);
    	
    	var user = userMock.Object as User;
    	
    	user.Dump(); // not null
    }
    
    public interface IUser
    {
    	int UserId { get; set; }
    }
    
    public class User : IUser
    {
    	public int UserId { get; set; }
    }
