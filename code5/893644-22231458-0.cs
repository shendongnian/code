		public class User {
		  public User() {
			// this constructor creates an object representing a brand new user
		  }
		  protected User(MyDbObject dbObject) {
			// creates an object representing an existing user, from a database object
		  }
		  public static User GetUser(MyDbObject dbObject) {
			return User(dbObject);
		  }
		}
		public class ExtendedUser : User {
		  public object ExtendedProperty { get; set; }
		  
		  private ExtendedUser(MyDbObject dbObject) : base(dbObject)
		  {
			//add extra data onto the base class here
		  }
		  public static ExtendedUser GetExtendedUser(MyDbObject dbObj) {
			return new ExtendedUser(dbObject);
		  }
		}
