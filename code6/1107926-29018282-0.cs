        //Dictionary of grades with default counts of 0 per grade
        var dict = new Dictionary<char, int>()
        {
            {'a', 0},
            {'b', 0},
            {'c', 0},
            {'d', 0},
            {'f', 0},
        };
        var acceptedGradeCount = 0;
        //While accepted grade count is less than 10
        while (acceptedGradeCount < 10)
        {
            Console.WriteLine("Enter a letter grade: ");
            //Read in the character and convert it to lower case
            var input = char.ToLower(Convert.ToChar(Console.ReadLine()));
            //Determine if the character is a valid grade by seeing if it exists in the dictionary
            if (dict.ContainsKey(input))
            {
                //Add 1 to the dictionary count value for that grade
                dict[input]++;
                acceptedGradeCount++;
            }
            else
            {
                Console.WriteLine("Incorrect letter grade entered. {0}Enter a new grade", Environment.NewLine);
            }
        }
        //Get results string
        var builder = new StringBuilder("Totals for each letter grade are:");
        foreach (KeyValuePair<char, int> keyValuePair in dict)
        {
            builder.Append(string.Format("{0}: {1} ", keyValuePair.Key, keyValuePair.Value));
        }
        //Print Results
        Console.WriteLine(builder.ToString());
        Console.ReadLine();
