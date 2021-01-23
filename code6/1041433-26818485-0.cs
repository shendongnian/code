    public static void Main(string[] args)
    {
    	double[] array = {1.2, 2.3, 3.4, 4.5, 8.9};
    	double average = array.Average();
    	double sd = Math.Sqrt(array.Sum(x => Math.Pow(x - average, 2) / array.Length));
    	Console.WriteLine("Average: " + average);
    	Console.WriteLine("Standard deviation: " + sd);
    }
