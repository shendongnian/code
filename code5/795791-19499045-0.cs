       public static void Main()
       {
          string line;
          Console.WriteLine("Enter one or more lines of text (press CTRL+Z to exit):");
          Console.WriteLine();
          do { 
             Console.Write("   ");
             line = Console.ReadLine();
             if (line != null) 
                Console.WriteLine("      " + line);
          } while (line != null);  
