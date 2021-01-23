	public class Car
	{     
		public int Mileage
		{
			get ;
			set ;
		}   
	}
	public class Audi : Car
	{
		public override string ToString()
		{
			return "I'm a Audi";
		}
	}
	public class BMW : Car
	{
		public override string ToString()
		{
			return "I'm a BMW";
		}
	}
	public class Program
	{
		//outside this class either a BMW class or Audi class is instantiated
		Audi _newCar = new Audi();
		// I don't know which one it is so I use a generic type
		Car MyCar;
		int Mileage;
		Program()
		{
			// Now I cast the unknown class to the car type
			MyCar = _newCar;
			// Although I know both Audi & BMW have the Mileage property, I cannot use it
			Mileage = MyCar.Mileage;
		}
	}
