    // Start at zero
    for (int i = 0; i < this.Length; i++) 
    {
        // If this is not the first element in the array
        //   and the new element is smaller than the previous
        if (i > 0 && this[i] < this[i-1]) 
        {
            // Then insert a new line into the output
            Console.Write(Environment.NewLine);
        }
        Console.Write(this[i] + " ");
    }
