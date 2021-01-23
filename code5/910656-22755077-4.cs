    [JsonConverter(typeof(TolerantEnumConverter))]
    enum Status
    {
        Ready = 1,
        Set = 2,
        Go = 3
    }
    [JsonConverter(typeof(TolerantEnumConverter))]
    enum Color
    {
        Red = 1,
        Yellow = 2,
        Green = 3,
        Unknown = 99
    }
    class Foo
    {
        public Status NonNullableStatusWithValidStringValue { get; set; }
        public Status NonNullableStatusWithValidIntValue { get; set; }
        public Status NonNullableStatusWithInvalidStringValue { get; set; }
        public Status NonNullableStatusWithInvalidIntValue { get; set; }
        public Status NonNullableStatusWithNullValue { get; set; }
        public Status? NullableStatusWithValidStringValue { get; set; }
        public Status? NullableStatusWithValidIntValue { get; set; }
        public Status? NullableStatusWithInvalidStringValue { get; set; }
        public Status? NullableStatusWithInvalidIntValue { get; set; }
        public Status? NullableStatusWithNullValue { get; set; }
        public Color NonNullableColorWithValidStringValue { get; set; }
        public Color NonNullableColorWithValidIntValue { get; set; }
        public Color NonNullableColorWithInvalidStringValue { get; set; }
        public Color NonNullableColorWithInvalidIntValue { get; set; }
        public Color NonNullableColorWithNullValue { get; set; }
        public Color? NullableColorWithValidStringValue { get; set; }
        public Color? NullableColorWithValidIntValue { get; set; }
        public Color? NullableColorWithInvalidStringValue { get; set; }
        public Color? NullableColorWithInvalidIntValue { get; set; }
        public Color? NullableColorWithNullValue { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            {
                ""NonNullableStatusWithValidStringValue"" : ""Set"",
                ""NonNullableStatusWithValidIntValue"" : 2,
                ""NonNullableStatusWithInvalidStringValue"" : ""Blah"",
                ""NonNullableStatusWithInvalidIntValue"" : 9,
                ""NonNullableStatusWithNullValue"" : null,
                ""NullableStatusWithValidStringValue"" : ""Go"",
                ""NullableStatusWithValidIntValue"" : 3,
                ""NullableStatusWithNullValue"" : null,
                ""NullableStatusWithInvalidStringValue"" : ""Blah"",
                ""NullableStatusWithInvalidIntValue"" : 9,
                ""NonNullableColorWithValidStringValue"" : ""Green"",
                ""NonNullableColorWithValidIntValue"" : 3,
                ""NonNullableColorWithInvalidStringValue"" : ""Blah"",
                ""NonNullableColorWithInvalidIntValue"" : 0,
                ""NonNullableColorWithNullValue"" : null,
                ""NullableColorWithValidStringValue"" : ""Yellow"",
                ""NullableColorWithValidIntValue"" : 2,
                ""NullableColorWithNullValue"" : null,
                ""NullableColorWithInvalidStringValue"" : ""Blah"",
                ""NullableColorWithInvalidIntValue"" : 0,
            }";
            Foo foo = JsonConvert.DeserializeObject<Foo>(json);
            foreach (PropertyInfo prop in typeof(Foo).GetProperties())
            {
                object val = prop.GetValue(foo, null);
                Console.WriteLine(prop.Name + ": " + 
                                 (val == null ? "(null)" : val.ToString()));
            }
        }
    }
