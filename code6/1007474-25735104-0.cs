                public class DateChecker
                {
                    public virtual uint USED_BY_YEAR { get; set; }
                    public virtual uint USED_BY_MONTH { get; set; }
                    public virtual uint USED_BY_DAY { get; set; }
                    public DateChecker()
                    {
                        USED_BY_YEAR = 2015;
                        USED_BY_MONTH = 3;
                        USED_BY_DAY = 31;
                    }
                    public virtual void checkUsedByDate()
                    {
                        Console.Write(string.Format("DATE: {0}/{1}/{2}", USED_BY_DAY, USED_BY_MONTH, USED_BY_YEAR));
                    }
                }
             public class CustomDateChecker : DateChecker
            {
                public override uint USED_BY_DAY
                {
                    get
                    {
                        return 9;
                    }
                    set
                    {
                        base.USED_BY_DAY = value;
                    }
                }
                public override uint USED_BY_MONTH
                {
                    get
                    {
                        return 9;
                    }
                    set
                    {
                        base.USED_BY_MONTH = value;
                    }
                }
                public override uint USED_BY_YEAR
                {
                    get
                    {
                        return 2014;
                    }
                    set
                    {
                        base.USED_BY_YEAR = value;
                    }
                }        
            }
            class Program
            {        
                static void Main(string[] args)
                {
                    new CustomDateChecker().checkUsedByDate();
                }
            }
