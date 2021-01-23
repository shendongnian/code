    public class Manager : Person
    {
        public Manager()
        {
            s = "Hello";
        }
        private string s;
        public override string Name { get; set; }
        public override void Introduce()
        {
            Console.WriteLine(s.ToLower());
        }
    }
