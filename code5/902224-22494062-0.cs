    if (number >= 10 && number <= 100)
    {
       bool containsNumber = false;
       for (int j = 0; j < count; j++)
       {
           if (number == numbers[j])
                containsNumber = true;
       }
       if (!containsNumber)
       {
          if (count < numbers.Length)
                numbers[count] = number;
          Console.WriteLine(number);
       }
       else
       {
           Console.WriteLine("{0} has already been entered", number);
       }
       for (int j = 0; j < count; j++)
       {
           if (numbers[j] > 0)
              Console.WriteLine("{0}", numbers[j]);
       }
       ++count;
