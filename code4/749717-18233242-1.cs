    class Program
    {
        static void Main(string[] args)
        {
            string json =
                "{'id':'2160336','activation_date':'2013-08-01','expiration_date':'2013-08-29','title':'Practice Manager','locations':{'103':'Cambridge','107':'London'}}";
            var deserializeObject = JsonConvert.DeserializeObject<ItemResults>(json);
            Console.WriteLine("{0}:{1}", deserializeObject.Locations.First().Key, deserializeObject.Locations.First().Value);
            Console.ReadKey();
        }
    }
    public class ItemResults
    {
        public int Id { get; set; }
        public DateTime Activation_Date { get; set; }
        public DateTime Expiration_Date { get; set; }
        public string Title { get; set; }
        public Dictionary<int, string> Locations { get; set; }
    }
