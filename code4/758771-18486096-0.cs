    public class MyEditor
    {
        public MyEditor()
        {
            Items = new ObservableCollection<ExpandoObject>
            {
                CreateItem(1, "John"),
                CreateItem(2, "Mary"),
                CreateItem(3, "Peter"),
                CreateItem(4, "Sarah")
            };
        }
        private ExpandoObject CreateItem(int id, string name)
        {
            dynamic item = new ExpandoObject();
            item.Id = id;
            item.Name = name;
            return item;
        }
        public ObservableCollection<ExpandoObject> Items { get; private set; }
    }
