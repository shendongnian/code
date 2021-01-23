    static void Main()
    {
        List<double> nums = new List<double>();
        for (double i = 0; i < 12; i++)
        {
            nums.Add(Fibonacci(i));
        }
        MessageBox.Show(string.Join(System.Environment.NewLine, nums));
    }
