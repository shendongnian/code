    class Program
    {
        static void Main(string[] args)
        {
            List<MightThrow> list = new List<MightThrow>
            {
                new MightThrow { Flags = ThrowFlags.None, Name = "none throw" },
                new MightThrow { Flags = ThrowFlags.A, Name = "A throws" },
                new MightThrow { Flags = ThrowFlags.B, Name = "B throws" },
                new MightThrow { Flags = ThrowFlags.Both, Name = "both throw" },
            };
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ContractResolver = new CustomResolver();
            settings.Formatting = Formatting.Indented;
            string json = JsonConvert.SerializeObject(list, settings);
            Console.WriteLine(json);
        }
    }
    [Flags]
    enum ThrowFlags
    {
        None = 0,
        A = 1,
        B = 2,
        Both = 3
    }
    class MightThrow
    {
        public string Name { get; set; }
        public ThrowFlags Flags { get; set; }
        public string A
        {
            get
            {
                if ((Flags & ThrowFlags.A) == ThrowFlags.A)
                    throw new Exception();
                return "a";
            }
        }
        public string B
        {
            get
            {
                if ((Flags & ThrowFlags.B) == ThrowFlags.B)
                    throw new Exception();
                return "b";
            }
        }
    }
