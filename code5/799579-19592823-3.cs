    public static class Class1
    {
        public static int? ParseInt(string value)
        {
            // Match any digits at the beginning of the string with an optional
            // character for the sign value.
            var match = Regex.Match(value, @"^-?\d+");
            if(match.Success)
                return Convert.ToInt32(match.Value);
            else
                return null; // Because C# does not have NaN
        }
    }
    ...
    var int1 = Class1.ParseInt("1.15"); // returns 1
    var int2 = Class1.ParseInt("123abc456"); // returns 123
    var int3 = Class1.ParseInt("abc"); // returns null
    var int4 = Class1.ParseInt("123"); // returns 123
    var int5 = Class1.ParseInt("-1.15"); // returns -1
    var int6 = Class1.ParseInt("abc123"); // returns null
