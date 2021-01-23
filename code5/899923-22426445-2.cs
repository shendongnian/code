    static void Main(string[] args)
            {
                var theGrade = 89;
                var gradeLookup = new Dictionary<Func<int, bool>, Action>
                        { 
                            { x => x >= 90, () => ShowMessage("You got an A!") },
                            { x => x >= 80 && x < 90, () => ShowMessage("You got an B!") },
                        };
    
                gradeLookup.First(x => x.Key(theGrade)).Value();
    
                Console.ReadKey();
            }
    
            static void ShowMessage(string msg)
            {
                Console.WriteLine(msg);
            }
