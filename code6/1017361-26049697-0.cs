    class Program
        {
            static void Main(string[] args)
            {
                List<Frog> numbers = new List<Frog>();
    
                numbers.Add(new Frog { name = "balcha" });
                numbers.Add(new Frog { name = "Tibara" });
                numbers.ForEach(n => n.name = "Bontu");
                numbers.ForEach(n => Console.WriteLine(n.name));
                Console.ReadLine();
            }
    
            class Frog
            {
                public string name { get; set; }
            }
        }
