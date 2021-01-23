     private static string ConvertInToDateTime(string DateTime)
        {
            string[] SplitDate = DateTime.Split(':');
            string[] SplitDateTime = null;
            if (SplitDate[1].Contains("+"))
                SplitDateTime = SplitDate[1].Split('+');
            else if (SplitDate[1].Contains("-"))
                SplitDateTime = SplitDate[1].Split('-');
            string TimeStamp = SplitDateTime[0].Insert(12, ":").Insert(10, ":").Insert(8, " ").Insert(6, "-").Insert(4, "-");
            return TimeStamp;
        }
