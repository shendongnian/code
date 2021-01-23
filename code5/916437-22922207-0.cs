    void Main()
    {
        Console.WriteLine("abc".GetEnumValue<A>()); // AA
        Console.WriteLine("ABC".GetEnumValue<A>()); // AA
        Console.WriteLine("AA".GetEnumValue<A>());  // AA
        Console.WriteLine("Bb".GetEnumValue<A>());  // BB
    }
    
    [JsonConverter(typeof(StringEnumConverter))]
    enum A
    {
        [EnumMember(Value = "abc")]
        AA,
        BB,
        CC,
        DD
    }
    public static class Ext
    {
        public static T GetEnumValue<T>(this string stringValue)
                where T : struct, IComparable, IConvertible, IFormattable
        {
            return JsonConvert.DeserializeObject<T>('"' + stringValue + '"');
        }
    }
