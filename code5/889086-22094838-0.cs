    public class SomeClass
    {
        public int State {get; set;}
        public DateTime Date{get; set;}
    }
    public void somemethod()
    {
        var list = new List<SomeClass>();
        list.Add(new SomeClass{State = 5});
        // Get all the items with state 5
        var itemsWithStateFive = list.Where(item => item.State == 5); 
        // Find the first index of an item that has state 5
        var indexOfStateFive = list.FindIndex(item => item.State == 5); 
    }
