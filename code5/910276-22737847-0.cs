    public int[] GenerateNonRepeatingNumbers(int seed, int min, int range)
        {
            // Make sure range is an appropriate value
            if (range <= 0)
            {
                throw new ArgumentException("Range must be greater than zero.");
            }
            // Make an array to hold our numbers
            int[] numbers = new int[range];
            // Seed the RNG.
            Random rng = new Random(seed);
            // Fill the array with all numbers from min to min + range
            for (int i = 0; i < range; numbers[i] = min + i++) { }
            int
                a = 0, // Swap index
                t = 0; // Temporary value storage
            // Scramble the values
            for (int i = 0; i < range; i++)
            {
                while ((a = rng.Next(range)) == i) { }; // Get a random index that isn't i
                t = numbers[i]; // Store the old value
                numbers[i] = numbers[a]; // Change the old value to the value at the random index
                numbers[a] = t; // Set value at random index to our old value from numbers[i]
            }
            return numbers;
        }
