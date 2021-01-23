    namespace WpfApplication1
	{
		public partial class MainWindow : Window
		{
			//private List<Car> myCars = new List<Car>();
			private List<Vehicle> myVehicles = new List<Vehicle>();
			private class Vehicle
			{
				public Car MyCar { get; set; }
			}
			private abstract class Car
			{
				public string Type { get; set; }
				public string Color { get; set; }
				public int DoorsNo { get; set; }
			}
			private class SimpleCar : Car { }
			private class FancyCar : Car { }
			public MainWindow()
			{
				InitializeComponent();
			}
			private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
			{
				var car1 = new SimpleCar() { Type = "hatchback", Color = "blue", DoorsNo = 5 };
				var car2 = new SimpleCar() { Type = "sedan", Color = "red", DoorsNo = 4 };
				var car3 = new SimpleCar() { Type = "sedan", Color = "blach", DoorsNo = 4 };
				var car4 = new FancyCar() { Type = "fancy", Color = "white", DoorsNo = 3 };
				var car5 = new FancyCar() { Type = "veryFancy", Color = "yellow", DoorsNo = 3 };
				//myCars.Add(car1);
				//myCars.Add(car2);
				//myCars.Add(car3);
				var vehicle1 = new Vehicle() { MyCar = car1 };
				var vehicle2 = new Vehicle() { MyCar = car2 };
				var vehicle3 = new Vehicle() { MyCar = car3 };
				var vehicle4 = new Vehicle(){MyCar = car4};
				var vehicle5 = new Vehicle(){MyCar = car5};
				myVehicles.Add(vehicle1);
				myVehicles.Add(vehicle2);
				myVehicles.Add(vehicle3);
				myVehicles.Add(vehicle4);
				myVehicles.Add(vehicle5);
				var onlySimpleCars = from vehicle in myVehicles
									  where (vehicle.MyCar.GetType() == typeof(SimpleCar))
									  select vehicle.MyCar;
				var allCars = from vehicle in myVehicles
								  select vehicle.MyCar;
				grdMyData.ItemsSource = onlySimpleCars.ToList();
				grdMyData2.ItemsSource = allCars.ToList();
			}
		}
	}
