    class Program
    {
        static Cylinder GetCylinderFromUser()
        {
            double radius, height;
            Console.Write("Enter radius: ");
            radius = double.Parse(Console.ReadLine());
            Console.Write("Enter height: ");
            height = double.Parse(Console.ReadLine());
            return new Cylinder(radius, height); 
        }
        static void Main()
        {
            Cylinder c = GetCylinderFromUser();
            Console.WriteLine("Created cylinder with height={0} and radius={1}",
                              c.Height, // replaces {0} with height of c
                              c.Radius  // replaces {1} with radius of c
                           );
            double volume = c.GetVolume();
            Console.WriteLine("The volume of the cylinder is {0}.", volume);
            Console.ReadLine();
                                  
        }
    }
