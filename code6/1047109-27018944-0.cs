    public class Object21
    {
        public int Id { get; set; }
        public bool FirstBool { get; set; }
        public bool SecondBool { get; set; }
        public bool ThirdBool { get; set; }
        public bool FourthBool { get; set; }
        public bool FifthBool { get; set; }
        public bool SixthBool { get; set; }
    
        public void Process()
        {
            // Perform the action
            Actions[Key]();
        }
    
        public string Key
        {
            get
            {
                return string.Join(string.Empty, GetType()
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(x => x.PropertyType == typeof(bool))
                    .Select(x => (bool)x.GetValue(this, null) ? "1" : "0" ));
            }
        }
    
        private static Dictionary<string, Func<int>> Actions
        {
            get
            {
                return new Dictionary<string, Func<int>>
                {
                    {"000000", new Func<int>(delegate
                    {
                        Console.WriteLine("000000 action performed.");
                        return 0;
                    })},
                    {"000001", new Func<int>(delegate
                    {
                        Console.WriteLine("000001 action performed.");
                        return 1;
                    })},
                    {"000010", new Func<int>(delegate
                    {
                        Console.WriteLine("000010 action performed.");
                        return 2;
                    })},
    
                    // More actions
    
                    {"111111", new Func<int>(delegate
                    {
                        Console.WriteLine("111111 action performed.");
                        return 63;
                    })}
                };
            }
        }
    }
