	class Engine
	{
		public Engine( ) { }
		public Engine( Engine e ) { Horesepower = e.Horesepower; }
		public int Horesepower = 500;
	}
	class Vehicle : ICloneable
	{
		public Vehicle( Engine engine ) { Engine = engine; }
		public Vehicle( Vehicle v ) { Engine = new Engine( v.Engine ); }
		public Engine Engine;
		public object Clone( )
		{
			Vehicle newVehicle = new Vehicle( this );
			return newVehicle;
		}
	}
