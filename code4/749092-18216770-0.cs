    public class MyTimeData {
        public int ID { get; set; }
        public int Time { get; set; }
    }
    var list = new SortedList<MyTimeData>();
    
    // Add items to sorted list
    // Reverse to make it descending
    var listDescending = list.Reverse();  
    foreach (var item in listDescending)
    {
        // Do something with item
    }
