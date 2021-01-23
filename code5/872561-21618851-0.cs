    class Program
    {
        static void Main(string[] args)
        {
            string myString = "01/02/2013";
            DateTime tempDate;
            if (!DateTime.TryParse(myString, out tempDate))
                Console.WriteLine("Invalid Date");
            else
            {
                var month = tempDate.Month.ToString();
                var year = tempDate.Year.ToString();
                var day = tempDate.Day.ToString();
                Console.WriteLine("The day is {0}, the month is {1}, the year is {2}", day, month, year);
            }
            Console.ReadLine();
        }
    }
