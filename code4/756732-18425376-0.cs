            byte[][] scores = new byte[5][];
            // Create the jagged array
            for (int i = 0; i < scores.Length; i++)
            {
                scores[i] = new byte[i + 3];
            }
            // Print length of each row
            for (int i = 0; i < scores.Length; i++)
            {
                Console.WriteLine("Length of row {0} is {1}", i, scores[i].Length);
                Console.ReadLine(); <------ Press enter here to continue, If you want your output like MSDN's, remove this line and the program will output all results
            }
