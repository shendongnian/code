    public static class Class1
    {
        public static int? ParseInt(string value)
        {
            var match = Regex.Match(value, @"\d+");
            if(match.Success)
                return Convert.ToInt32(match.Value);
            else
                return null;
        }
    }
    ...
    var int1 = Class1.ParseInt("1.15"); // returns 1
    var int2 = Class1.ParseInt("123abc456"); // returns 123
    var int3 = Class1.ParseInt("abc"); // returns NULL (C# does not have NaN)
    var int4 = Class1.parseInt("123"); // returns 123
