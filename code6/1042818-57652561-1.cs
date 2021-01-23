    using System;
    
    namespace ConsoleEnum
    {
       class host
       {
          [STAThread]
          static void Main(string[] args)
          {
             // Create an arary of car objects.      
             car[] arrayOfCars= new car[6]
             {
                new car("Ford",1992),
                new car("Fiat",1988),
                new car("Buick",1932),
                new car("Ford",1932),
                new car("Dodge",1999),
                new car("Honda",1977)
             };
          
             // Write out a header for the output.
             Console.WriteLine("Array - Unsorted\n");
    
             foreach(car c in arrayOfCars)
                Console.WriteLine(c.Make + "\t\t" + c.Year);
          
             // Demo IComparable by sorting array with "default" sort order.
             Array.Sort(arrayOfCars);
             Console.WriteLine("\nArray - Sorted by Make (Ascending - IComparable)\n");
    
             foreach(car c in arrayOfCars)
                Console.WriteLine(c.Make + "\t\t" + c.Year);
    
             // Demo ascending sort of numeric value with IComparer.
             Array.Sort(arrayOfCars,car.sortYearAscending());
             Console.WriteLine("\nArray - Sorted by Year (Ascending - IComparer)\n");
    
             foreach(car c in arrayOfCars)
                Console.WriteLine(c.Make + "\t\t" + c.Year);
    
             // Demo descending sort of string value with IComparer.
             Array.Sort(arrayOfCars,car.sortMakeDescending());
             Console.WriteLine("\nArray - Sorted by Make (Descending - IComparer)\n");
    
             foreach(car c in arrayOfCars)
                Console.WriteLine(c.Make + "\t\t" + c.Year);
    
             // Demo descending sort of numeric value using IComparer.
             Array.Sort(arrayOfCars,car.sortYearDescending());
             Console.WriteLine("\nArray - Sorted by Year (Descending - IComparer)\n");
    
             foreach(car c in arrayOfCars)
                Console.WriteLine(c.Make + "\t\t" + c.Year);
         
             Console.ReadLine();
          }
       }
    }
