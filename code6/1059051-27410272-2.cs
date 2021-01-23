        do
        {
            line = Console.ReadLine();
            if (line != null)
                numbers[c++] = int.Parse(line); //assigning string to the last element in the array of ints?
                //if you need to parse string to int, use int.Parse() or Convert.ToInt32() 
                //whatever suits your needs
            numbers = new int[c+1];
        } while (!string.IsNullOrEmpty(line));
