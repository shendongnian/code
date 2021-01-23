     private class MySqlFunctions
        {
            [DbFunction("SqlServer", "DATEDIFF")]//EF will use this function
            public int? DateDiff(string datePartArg, DateTime startDate, DateTime endDate)
            {
                var subtract = startDate.Subtract(endDate);
                switch (datePartArg)
                {
                    case "d":
                        return (int?)subtract.TotalDays;
                    case "s":
                        return (int?)subtract.TotalSeconds; // unit test will use this one
                }
                throw new NotSupportedException("Method supports only s or d param");
            }
        }
