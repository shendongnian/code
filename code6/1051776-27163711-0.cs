    for (int i = 0; i < array.Length; i++)
                {
                    Console.WriteLine("Enter in a name and score: ");
                    string userInput = Console.ReadLine();
                    string[] parsedInput;
                    parsedInput = userInput.Split(' ');
                    string name = parsedInput[0];
                    int score = int.Parse(parsedInput[1]);
                    array[i] = score;
                }
