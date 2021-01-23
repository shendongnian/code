    public class Program
    {
        public static void Main(string[] args)
        {
            int i2, k, j;
            Console.WriteLine("How many elements you want to sort? ");
            i2 = Convert.ToInt32(Console.ReadLine());
            int[] values = new int[i2];
            int n1 = 0;
            int n = 0; ;
            int i;
            Console.WriteLine("Enter the elements of array {0}", n1);
            for (i = 0; i < i2; i++)
            {
                Console.WriteLine("Enter the elements of array {0}");
                n = Convert.ToInt32(Console.ReadLine());
                Convert.ToInt32(values[i] = n);
            }
            for (i = 0; i < i2; i++)
            {
                k = Convert.ToInt32(values[i]);
                for (j = i - 1; j >= 0 && k < values[j]; j--)
                    values[j + 1] = values[j];
                values[j + 1] = k;
            }
            for (i = 0; i < i2; i++)
            {
                Console.WriteLine("sorting elements {0}", values[i]);
            }
            Console.ReadLine();
        }
    }
}
