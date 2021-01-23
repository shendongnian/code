    public static class DateExtension
        {
            public static DateTime SqlValidDateTime(this DateTime d)
            {
                return SqlDateTime.MinValue.Value;
            }
        }
