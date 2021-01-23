    using System.Linq;
    ...
    int[] values = new int[10];
    // Fill array
    ...
    int[] usefulValues = values.Where(i => i <= 4095).ToArray();
    int numberOfUselessValues = values.Length - usefulValues.Length;
