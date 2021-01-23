    using System;
    
    namespace Conv
    {
    
    public class Centimeter
    {
        public int cmvar;
        public Centimeter()
        {
            cmvar = 0;
        }
    }
    
    //primary const to be added
    
    
    public class MeterToCenti
    {
        public static void Main()
        {
            char choice;
            char n = 'n';
            do
            {
                Centimeter c = new Centimeter();
                Console.WriteLine("enter value in centimeters");
                c.cmvar = int.Parse(Console.ReadLine());
                Printout(c);
                Console.WriteLine("Do you want to continue? (y/n)");
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }
            while (choice != n);
        }
    
    
    public static int getMeters(Centimeter c)
        {
    		int meters = c.cmvar / 100;
    		return meters;
        }
    
    
    public static int Remainder(Centimeter c)
        {
            int cmremain = c.cmvar % 100;
    		return cmremain;
        }
    
    
    public static void Printout(Centimeter c)
        {
            Console.WriteLine("{0} Meters and {1} Centimeters", getMeters(c), Remainder(c));
        }
    
    }
    
    
    }
