     public static class MyExtensions
     {
            public static string PersianToEnglish(this string persianStr)
            {
                Dictionary<string, string> LettersDictionary = new Dictionary<string, string>
                {
                    ["۰"] = "0",["۱"] = "1",["۲"] = "2",["۳"] = "3",["۴"] = "4",["۵"] = "5",["۶"] = "6",["۷"] = "7",["۸"] = "8",["۹"] = "9"
                };
                return LettersDictionary.Aggregate(persianStr, (current, item) =>
                             current.Replace(item.Key, item.Value));
            }
    }
