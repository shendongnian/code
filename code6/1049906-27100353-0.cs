    class MainClass
    {
        public static void Main (string[] args)
        {
            Random r = new Random ();
            List<string> words = new List<string>();
            Console.WriteLine ("Enter words for the random word generator. ");
    
            int a = 0;
            while(!(Console.ReadLine().Equals("END"))){
                words.Add(Console.ReadLine());
           }
    
            Console.WriteLine ();
            Console.WriteLine (words[r.Next(words.Count)]);
        }
    }
 
