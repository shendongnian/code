    Console.WriteLine("Enter in a name: ");
    string userInput = Console.ReadLine();
    for (int i = 0; i < array.Length; i++)
                {
                   
                    Console.WriteLine("Enter in a score "+i+": ");
                    string score = Console.ReadLine();
                    // store the second piece, a score, in an integer variable
                    int scores = int.Parse(score);
                    array[i] = scores;
                }
