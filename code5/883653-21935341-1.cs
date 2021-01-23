    internal class Program
        {
            private static void Main(string[] args)
        {
            
            List<MyObject> list = new List<MyObject>();
            for (int i = 0; i < 5; i++)
            {
                list.Add(new MyObject() {Id = i}
                    );
            }
            List<MyObject> list2 = new List<MyObject>();
            for (int i = 0; i < 5; i++)
            {
                list2.Add(new MyObject() {Id = i});
            }
            int total = 10;
            list.AddRange(list2.Take(total - list.Count));
        }
        class MyObject
        {
            public int Id { get; set; }
        }
    }
