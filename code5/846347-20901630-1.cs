     public enum Days
        {
            Sunday = 0,
            Monday,
            Tuesday,
            WednessDay,
            Thursday,
            Friday,
            Saturday,
            Once
        }
        public class Day
        {
    
            public Days AssociateDay { get; set; } // used enum for better coding
            public DateTime Time { get; set; }
        }
    public class Program
    {
        public Program()
        {
            Days=new List<Day>();
        }
        public int Id { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public List<Day> Days { get; private set; }
        public void AddDay(Day day)
        {
            if(Days.Any(x=>x.AssociateDay==day.AssociateDay))
            { // i dont know whats ur logic  here i am  returning without doing anything
                return;
                
            }
            Days.Add(day);
            
        }
        
    }
    public class MyProgram
    {
        private static void Main(string[] args)
        {
            List<Program> Programs = new List<Program>();
            // Code to add new Program
            Program urProgram = new Program {FileName = "UrFile.aspx", FilePath = "Ur System Drive",Id = 1};
            urProgram.AddDay(new Day{AssociateDay = Days.Sunday,Time = DateTime.Now});
            Program myprogram = new Program { FileName = "MyFile.aspx", FilePath = "My System Drive" ,Id = 2};
            urProgram.AddDay(new Day { AssociateDay = Days.Monday, Time = DateTime.Now });
            Program theireePrgram = new Program { FileName = "theireeFile.aspx", FilePath = "their System Drive", Id = 3 };
            theireePrgram.AddDay(new Day { AssociateDay = Days.Monday, Time = DateTime.Now });
            // Your program object created now you can add to list collection
            Programs.Add(urProgram);
            Programs.Add(myprogram);
            Programs.Add(theireePrgram);
            // Update a program 
            int id = 1;
            var pgmUpdate = Programs.First(x => x.Id == 1);
            pgmUpdate.AddDay(new Day{AssociateDay = Days.Monday,Time = DateTime.Now});
            // Delete a program
            id = 3;
            Programs.Remove(Programs.First(x => x.Id == id));
            // List all programs
            foreach (var program in Programs)
            {
                Console.WriteLine(program.Id);
                Console.WriteLine(program.FileName);
                Console.WriteLine(program.FilePath);
                foreach (var day in program.Days)
                {
                    Console.WriteLine(day.AssociateDay);
                    Console.WriteLine(day.Time);
                    Console.WriteLine("............................");
                }
                Console.WriteLine("*************************");
            }
            Console.ReadLine();
        }
    }
