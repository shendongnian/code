    public class ViewModel
    {
        public ObservableCollection<ItemA> ItemsA { get; set; }
        public ViewModel()
        {
            ItemsA = new ObservableCollection<ItemA>(new[]{
                new ItemA{Name = "A one"},
                new ItemA{Name = "A Two"},
                new ItemA{Name = "A Three"},
            });
        }
    }
    public class ItemA
    {
        public ObservableCollection<ItemB> ItemsB { get; set; }
        public string Name { get; set; }
        public ItemA()
        {
            ItemsB = new ObservableCollection<ItemB>(new[]{
                new ItemB{Name = "B one"},
                new ItemB{Name = "B Two"},
                new ItemB{Name = "B Three"},
            });
        }
    }
    public class ItemB
    {
        public ObservableCollection<ItemC> ItemsC { get; set; }
        public string Name { get; set; }
        public ItemB()
        {
            ItemsC = new ObservableCollection<ItemC>(new[]{
                new ItemC{Name = "C one"},
                new ItemC{Name = "C Two"},
                new ItemC{Name = "C Three"},
            });
        }
    }
    public class ItemC
    {
        public string Name { get; set; }
    }
