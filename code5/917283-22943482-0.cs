    void Main()
    {
        // compile a list of possible fruits (remember that c# arrays are
        // 0-indexed (first element is actually 0 and not 1))
        string[] fruits = new[]{
            "apples",
            "oranges",
            "pears"
        };
    
        // iterate over the options and output each one
        for (var i = 0; i < fruits.Length; i++){
            // add one to index value to make it non-0 based
            Console.WriteLine("Enter {0} to select {1}", i + 1, fruits[i]);
        }
    
        // continue to read user input until they select a valid choice
        Int32 choice = 0;
        do
        {
            // read user input
            String input = Console.ReadLine();
            // [try to] convert the input to an integer
            // if it fails, you'll end up with choice=0
            // which will force the while(...) condition to fail
            // and, therefore, retry for another selection.
            Int32.TryParse(input, out choice);
        }
        // number should be between 1 and (fruits.Length + 1)
        while (choice < 1 || choice > (fruits.Length + 1));
        
        // to reference it, subtract 1 from user's choice to get back to
        // 0-indexed array
        Console.WriteLine("You have selected {0} which is {1}", choice, fruits[choice - 1]);
    }
