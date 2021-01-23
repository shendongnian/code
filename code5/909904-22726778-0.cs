     public static IEnumerable<string> Parse(string commandLine)
        {
            foreach (var word in commandLine.Split(' '))
                yield return word;
        }
    
        static void Main(string[] args)
        {
            string testCommandLine = "Hello World";
            var passedArgs = Parse(testCommandLine);
            foreach (var word in passedArgs)
            { 
                //do some work
                Console.WriteLine(word);
            }
    
            Console.Read();
        }
