    public static void Main(string[] args)
            {
                Random numberGenerator = new Random ();
    
                int num01 = numberGenerator.Next (1,11);
                int num02 = numberGenerator.Next (1,11);
                int realAnswer = num01 * num02 ;
    
                Console.WriteLine ("What is " + num01 + " multiplied by " + num02 + "?");
    
                int userAnswer = Convert.ToInt32 (Console.ReadLine ());
    
                if (userAnswer == realAnswer) {
                    Console.WriteLine ("Good");
                } else if (userAnswer - realAnswer >= 1 && userAnswer - realAnswer <= 3) {
    
                    int greater = numberGenerator.Next (1, 3);
    
                    switch (greater) {
                    case 1:
                        Console.WriteLine ("little too high");
                    break;
    
                    default:
                        Console.WriteLine ("little too much");
                        break;
                    }
    
                    } else if ((realAnswer-userAnswer  >= 1) && (realAnswer-userAnswer  <=3)) {
    
                        int less = numberGenerator.Next (1, 3);
    
                        switch (less) {
                        case 1:
                            Console.WriteLine ("little too low");
                            break;
    
                        default:
                            Console.WriteLine ("go higher!");
                            break;
                        }
                } else {
    
                            Console.WriteLine ("you just suck");
    
                        }
    
                        Console.ReadKey ();
    
                        }
