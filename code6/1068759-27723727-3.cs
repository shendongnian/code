		static void Main( string[ ] args )
		{
			Engine v8 = new Engine( );
			v8.Horesepower = 1000; // this changes the field Engine in yugo as well
			Vehicle monsterTruck = new Vehicle( new Engine { Horesepower = v8.Horesepower } );
			Console.WriteLine( v8.Horesepower ); // prints 1000
			Console.WriteLine( monsterTruck.Engine.Horesepower ); // prints 1000
			v8.Horesepower = 800;
			monsterTruck.Engine.Horesepower = 1200;
			Console.WriteLine( v8.Horesepower ); // prints 800
			Console.WriteLine( monsterTruck.Engine.Horesepower ); // prints 1200
		}
