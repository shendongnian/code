    const string MyDateTimeFormat = "ddMMMMyyyy"
    public static void Main()
        {
            DateTime D = new DateTime();
            D = DateTime.Now;
            string s1 = D.ToString(MyDateTimeFormat );
            Console.WriteLine(s1);
            Console.WriteLine(DateTime.TryParseExact(s1,MyDateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out D));
            Console.ReadKey();
        }
