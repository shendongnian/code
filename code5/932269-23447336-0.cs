          public class MyContext : DbContext
          {
                public MyContext () : base("DefaultConnection")
                {
                }
                public static MyContext Create()
                {
                    return new MyContext ();
                }
          }
