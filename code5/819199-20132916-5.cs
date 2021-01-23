    using System.Collections.Generic; // put with other using directives
    List<int> numbers = new List<int>(SIZE); // Capacity == SIZE
    ...
    for (int input = 0; input < SIZE; input++)
    {
        ...
        if (numberInputed == ZERO)
        {
            break;
        }
        else
        {
            numbers.Add(numberInputed);
        }
    }
