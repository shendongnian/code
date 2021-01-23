    public class MyClass
    {
    
        public ObservableCollection<MyItem> myList {get; set;}
    
        
        public MyClass()
        {
            DataContext=this;
            myList = new ObservableCollection();
        
            myList.Add(new MyItem() { Text = "Abkhazia" });
            myList.Add(new MyItem() { Text = "Afghanistan" });
            myList.Add(new MyItem() { Text = "Albania" });
        }
    }
