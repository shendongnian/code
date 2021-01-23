    static class Program
    {
        static void Main()
        {
            var systemTime = new SystemTime(DateTime.Now);
            Console.WriteLine("ShortDatePattern (as reported by .NET): " + DateTimeFormatInfo.CurrentInfo.ShortDatePattern);
            var sbDate = new StringBuilder();
            GetDateFormat(0, 0, ref systemTime, null, sbDate, sbDate.Capacity);
            Console.WriteLine("Date string (as reported by kernel32) : " + sbDate);
            Console.WriteLine();
            Console.WriteLine("LongTimePattern (as reported by .NET) : " + DateTimeFormatInfo.CurrentInfo.LongTimePattern);
            var sbTime = new StringBuilder();
            GetTimeFormat(0, 0, ref systemTime, null, sbTime, sbTime.Capacity);
            Console.WriteLine("Time string (as reported by kernel32) : " + sbTime);
            Console.ReadKey();
        }
        [DllImport("kernel32.dll")]
        private static extern int GetDateFormat(int locale, uint dwFlags, ref SystemTime sysTime,
            string lpFormat, StringBuilder lpDateStr, int cchDate);
        [DllImport("kernel32.dll")]
        private static extern int GetTimeFormat(uint locale, uint dwFlags, ref SystemTime time, 
            string format, StringBuilder sb, int sbSize);
        [StructLayout(LayoutKind.Sequential)]
        private struct SystemTime
        {
            [MarshalAs(UnmanagedType.U2)] private readonly ushort Year;
            [MarshalAs(UnmanagedType.U2)] private readonly ushort Month;
            [MarshalAs(UnmanagedType.U2)] private readonly ushort DayOfWeek;
            [MarshalAs(UnmanagedType.U2)] private readonly ushort Day;
            [MarshalAs(UnmanagedType.U2)] private readonly ushort Hour;
            [MarshalAs(UnmanagedType.U2)] private readonly ushort Minute;
            [MarshalAs(UnmanagedType.U2)] private readonly ushort Second;
            [MarshalAs(UnmanagedType.U2)] private readonly ushort Milliseconds;
            public SystemTime(DateTime dateTime)
            {
                Year = (ushort) dateTime.Year;
                Month = (ushort) dateTime.Month;
                DayOfWeek = (ushort) dateTime.DayOfWeek;
                Day = (ushort) dateTime.Day;
                Hour = (ushort) dateTime.Hour;
                Minute = (ushort) dateTime.Minute;
                Second = (ushort) dateTime.Second;
                Milliseconds = (ushort) dateTime.Millisecond;
            }
        }
    }
