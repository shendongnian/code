    public static class XMLibrary
    {
        public static MC CalculateValues(this MC myclass)
        {
            //for each property calculate the values here
            if (myclass.Name == string.Empty) myclass.Name = "You must supply a name";
            if (myclass.Next == 0) myclass.Next = 1;
            //when done return the type
            return myclass;
        }
    }
    public class MC
    {
        public string Name { get; set; }
        public int Next { get; set; }
    }
    public class SomeMainClass
    {
        public SomeMainClass()
        {
            var mc = new MC { Name = "test", Next = 0 };
            var results = mc.CalculateValues();
        }
    }
