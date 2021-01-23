    public class Rootobject
    {
        public Root Root { get; set; }
    }
    public class Root
    {
        public Datum[] data { get; set; }
    }
    public class Datum
    {
        public string CardName { get; set; }
        public Function[] functions { get; set; }
    }
    public class Function
    {
        public string State { get; set; }
    }
