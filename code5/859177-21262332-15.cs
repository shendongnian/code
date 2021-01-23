    public class TestController : Service
	{
		// Roles: Santa, Rudolph, MrsClaus
		public object Get(HaveChristmasRequest request)
		{
			return new { Presents = "Toy Car, Teddy Bear, Xbox"  };
		}
		// Roles: Easterbunny
		public object Get(GetEasterEggRequest request)
		{
			return new { EasterEgg = "Chocolate" };
		}
		// No roles required
		public object Get(EinsteinsBirthdayRequest request)
		{
			return new { Birthdate = new DateTime(1879, 3, 14)  };
		}
	}
