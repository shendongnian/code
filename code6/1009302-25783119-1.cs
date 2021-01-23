    public class MyObject
    {
        public int[] productId { get; set; }
        public string[] ProductName { get; set; }
    }
    MyObject obj = JsonConvert.DeserializeObject<MyObject>(data); 
