    public partial class Test
        {
            public DateTime DateSi
            {
                get
                {
                    return ConvertIntToDate(Date)
                }
                set
                {
                    Date = ConvertDateToInt(value);
                }
            }
        }
