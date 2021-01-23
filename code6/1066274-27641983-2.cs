    class Program
    {
        static void Main(string[] args)
        {
            Item item = new Item();
            for (int x = 0; x < 4; x++)
            {
                string key = "MyProperty" + (x > 0 ? x.ToString() : "");
                string value = item.GetProperty<string>(key);
                Console.WriteLine("Getting {0} = {1}", key, value);
            }
            Console.ReadLine();
        }
    }
