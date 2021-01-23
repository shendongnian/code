    class work1
    {
        public static void Main(String[] args)
        {
            string[] height = Console.ReadLine().Split(' ');
            double[] heightInDouble = new Double[height.Length];
            for (int i = 0; i < height.Length; i++)
            {
                heightInDouble[i] = Convert.ToDouble(height[i]); // line 20
            }
            Console.WriteLine("Highest: " + heightInDouble.Max() + " Lowest: " + heightInDouble.Min());
            Console.ReadLine();
        }
    }
