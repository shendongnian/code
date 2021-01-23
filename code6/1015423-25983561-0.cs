	void Main()
	{
		// Car has inherited two properties from the VehicleBase class, 
		// the Brand propety, and the ProductionDate property
		Car car = new Car { Brand = "Foo", ProductionDate = DateTime.UtcNow };
		
		// The StartEngine method is declared in the class `Car`, and is available
		// to only its self, as there is no other class inheriting from it.
		car.StartEngine();
	
		// This is polymorphism... 
		VehicleBase vehicle = car;
		
		// As the VehicleBase class doesn't inherit from Car, it can not use
		// the StartEngine method... the only way to use it is by casting it 
		// back to a Car.
		Car castedCar = vehicle as Car;
		castedCar.StartEngine();
	
	}
	
	public class VehicleBase
	{
		public string Brand { get; set; }
		public DateTime ProductionDate { get; set; }
	}
	
	public class Car : VehicleBase
	{
		public void StartEngine()
		{
			Console.WriteLine ("Engine started");
		}
	}
