        static void Main(string[] args)
        {
            DateTime start1 = new DateTime(2013,1,2);
            DateTime end1 = new DateTime(2013,1,14);
            DateTime start2 = new DateTime(2013,1,1);
            DateTime end2 = new DateTime(2013,1,12);
            DateTime lateStart = GetLatest(start1, start2);
            DateTime earlyEnd = GetEarliest(end1, end2);
            Console.WriteLine((earlyEnd-lateStart).TotalDays + 1);
            Console.ReadLine();
        }
        private static DateTime GetEarliest(DateTime start1, DateTime start2)
        {
            return start1 < start2 ? start1 : start2;
        }
        private static DateTime GetLatest(DateTime start1, DateTime start2)
        {
            return start1 > start2 ? start1 : start2;
        }
