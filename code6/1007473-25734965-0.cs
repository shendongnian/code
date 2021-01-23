    public class DateChecker
        {
            public readonly uint USED_BY_YEAR = 2015;
            public readonly uint USED_BY_MONTH = 3;
            public readonly uint USED_BY_DAY = 31;
    
            public DateChecker()
            {
    
            }
    
            public DateChecker(uint d, uint m, uint y)
            {
                this.USED_BY_DAY = d;
                this.USED_BY_MONTH = m;
                this.USED_BY_YEAR = y;
            }
    
            public bool checkUsedByDate()
            {
                Console.WriteLine(string.Format("DATE: {0}/{1}/{2}", USED_BY_DAY, USED_BY_MONTH, USED_BY_YEAR));
                return false;
            }
        }
    
        public class CustomDateChecker : DateChecker
        {
            // Override Date
            public new const uint USED_BY_YEAR = 2014;
            public new const uint USED_BY_MONTH = 9;
            public new const uint USED_BY_DAY = 9;
    
            public CustomDateChecker()
                : base(USED_BY_DAY, USED_BY_MONTH, USED_BY_YEAR)
            {
            }
    
             
        }
    
        private static void Main(string[] args)
        {
            CustomDateChecker d = new CustomDateChecker();
            d.checkUsedByDate();
        }
