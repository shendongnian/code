    public class DataObject
    {
        public string FieldA { get; set; }
        public string FieldB { get; set; }
        public string FieldC { get; set; }
    }
    List<DataObject> items = new List<DataObject>();
    items.Add(new DataObject() {FieldA="foobar",FieldB="foobar",FieldC="foobar"});
    items.Add(new DataObject() { FieldA = "foobar", FieldB = "foobar", FieldC = "foobar" });
    items.Add(new DataObject() { FieldA = "foobar", FieldB = "foobar", FieldC = "foobar" });
    
    dg.ItemsSource = items;
    
