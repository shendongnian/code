    public static class MyExtensions
    {
         public static string PersianToEnglish(this string persianStr)
         {
                Dictionary<char, char> LettersDictionary = new Dictionary<char, char>
                {
                    ['۰'] = '0',['۱'] = '1',['۲'] = '2',['۳'] = '3',['۴'] = '4',['۵'] = '5',['۶'] = '6',['۷'] = '7',['۸'] = '8',['۹'] = '9'
                };
                foreach (var item in persianStr)
                {
                    persianStr = persianStr.Replace(item, LettersDictionary[item]);
                }
                return persianStr;
         }
    }
