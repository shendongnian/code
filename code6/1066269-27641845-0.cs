    public class Apple
    {
        public string Color { get; set; }
    }
    public List<Apple> ApplesList {get;set;}
    public void Process()
    {
        PropertyInfo pi = typeof(Apple).GetProperty("Color");
        ApplesList = ApplesList.Where(r => (string)pi.GetValue(r) == "Red").ToList();
    }
