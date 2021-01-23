    static void Main()
    {
        String input = File.ReadAllText(@"test.txt");   // read file content
        input = input.Replace("\r\n", "\n");            // get rid of \r
        int i = 0, j = 0;
        string[,] result = new string[10,10];           // hardcoded for testing purposes
        foreach (var row in input.Split('\n'))          // loop through each row
        {
            j = 0;
            foreach (var col in row.Select(c => c.ToString()).ToArray()) // split to array
            {                                                            // and loop through each char
                result[i, j] = col;                                      // Add the char to the jagged array => result
                j++;
            }
            i++;
        }
    }
    // EDIT: added some code to print out the result.
    // Print all elements in the 2d array.
    int rowLength = result.GetLength(0);
    int colLength = result.GetLength(1);
    for (int k = 0; k < rowLength; k++)
    {
        for (int h = 0; h < colLength; h++)
        {
            Console.Write("{0} ", result[k, h]);
        }
        Console.Write(Environment.NewLine + Environment.NewLine);
    }
