    namespace ConsoleApplication2
    {
        class Words
        {                     
            List<string> ordlista;
            Random rng; 
            public Words()
            {
                ordlista = new List<string>();
            }
            public void AddWord(string s)
            {
                ordlista.Add(s);
            }
            public string GetRandomWord()
            {
                if(rng==null)
                    rng = new Random();
                return ordlista[rng.Next(ordlista.Count)];
            }
        }
        class Program
        {        
            static void Main(string[] args)
            {
                Words wordManager = new Words();
                Console.WriteLine("\n\n\tSkriv in dina fem ord");
                
                for(int i=0;i<5;i++)
                wordManager.AddWord(Console.ReadLine());            
                Console.WriteLine(wordManager.GetRandomWord());
            }
        }
    }
