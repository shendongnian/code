        public static class SingleLetterMonthNameFormatter
        {
            private static IFormatProvider _formatProvider;
            public static IFormatProvider FormatProvider
            {
                get
                {
                    if (_formatProvider == null)
                    {
                        var dtfi = new DateTimeFormatInfo();
                        dtfi.AbbreviatedMonthNames = dtfi.MonthNames.Select(x => x.FirstOrDefault().ToString()).ToArray();
                        _formatProvider = dtfi;
                    }
                    return _formatProvider;
                }
            }
        }
