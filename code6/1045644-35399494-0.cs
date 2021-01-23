    {
        static void Main(string[] args)
        {
            Console.Write("Please enter a temperature: "); 
            
            int temp = Convert.ToInt32(Console.ReadLine()); 
            
            if (temp >= 90) { Console.WriteLine("fish"); } 
            
            else if (temp >= 80) { Console.WriteLine("Lion"); } 
            
            else if (temp >= 70) { Console.WriteLine("Turle"); } 
            
            else if (temp >= 60) { Console.WriteLine("Deer"); } 
            
            else if (temp >= 50) { Console.WriteLine("Reindeer"); } 
            
            else if (temp >= 40) { Console.WriteLine("Moose"); } 
            
            else if (temp >= 20) { Console.WriteLine("Penguin"); } 
            
            else if (temp >= 10) { Console.WriteLine("Polar Bear"); } 
            
            else { Console.WriteLine("Bug"); }
        }
    }
}
