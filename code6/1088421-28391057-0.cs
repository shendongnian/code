    class Forms
    {
        public static void Main(string[] args)
        {
            int  endTimeHours = -4;;
            int endTimeMins = -30;
            string temp = string.Format("{0:d2}" + "{1:d2}", endTimeHours, int.Parse(endTimeMins.ToString().Remove(0, 1)));
            Console.WriteLine(temp);
        }
    }
