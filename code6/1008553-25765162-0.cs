    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace Program
    {
    class Third
    {
    public static void Main()
    {
        Console.WriteLine("Enter how much numbers");
        int howMuch = int.Parse(Console.ReadLine());
        int[] num = new int[howMuch];
        for(int i = 0; i < howMuch; ++i)
        {
            //This is assuming that the user will enter an int value.
            //Ideally, verify this using int.TryParse or something similar.
            num[i] = int.Parse(Console.ReadLine());
        }
        int sum = 1; //Set to 1 so that the PRODUCT is not always zero
        for (int i = 0; i < num.Length; i++ )
        {
            sum *= num[i]; //Multiply the value
        }
        Console.WriteLine(sum);
        Console.ReadLine();
    }
    }
