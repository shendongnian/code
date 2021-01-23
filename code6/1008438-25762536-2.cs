    using System.Collections.Generic;
    using System.Linq;
 ---
    var r = new Random();
    var numbers = new List<int>();
    while (numbers.Count < 100)
    {
        var stack = new Stack<int>();
        for (int i = 0; i < 10; i++)
        {
            stack.Push(r.Next(10));
        }
        if (stack.Sum() == 70)
        {
            numbers.AddRange(stack);
        }
    }
    Console.WriteLine(numbers.Average());
