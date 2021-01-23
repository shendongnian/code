    public class MyTimeData {
       public int ID { get; set; }
       public int Time { get; set; }
    }
    var list = new List<MyTimeData>();
    // Add items to the list
    list = list.OrderByDescending(d => d.Time).ToList();
