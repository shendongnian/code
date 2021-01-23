    C# class
    public class Item
    {
        public string itemid { get; set; }
    }
    public class Inner
    {
        public string key { get; set; }
        public List<Item> items { get; set; }
    }
    public class Outer
    {
    public List<Inner> inner { get; set; }
    }
    public class RootObject
    {
        public List<Outer> outer { get; set; }
     }
