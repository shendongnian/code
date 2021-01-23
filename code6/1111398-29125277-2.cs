    using System;
    using System.Collections.Generic;
    
    class Test
    {
        static void Main()
        {
            int outerCounter = 0;
            var actions = new List<Action>();
            for (int i = 0; i < 5; i++)
            {
                outerCounter = i * 10;
                int innerCounter = i * 10;
                // Using an anonymous method here as per question;
                // you'd see the same behaviour with a lambda expression.
                actions.Add(delegate {
                    Console.WriteLine("{0}: {1}", outerCounter, innerCounter);
                });
                
                innerCounter++;
            }
            
            foreach (var action in actions)
            {
                action();
            }
        }
    }
