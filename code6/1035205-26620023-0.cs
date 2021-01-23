    private static void AddCar(List<Vehicle> vehicles)
    {
          
          Console.Clear();
          Console.Write("/////////////////////ADDING CAR DETAILS\\\\\\\\\\\\\\\\\\\\\\\\");
          var v = new Vehicle();
          Console.Write("\n\nEnter Make: ");
          v.Make = Console.ReadLine();
          
          Console.Write("\n\nEnter Model: ");
          v.Model = Console.ReadLine();
          
          Console.Write("\n\nEnter Year: ");
          v.Year = Console.ReadLine();
         
          vehicles.Add(v);
          Console.WriteLine(string.Join(", ", vehicles.Select(_ => _.ToString())));
          Console.ReadKey();
    }
