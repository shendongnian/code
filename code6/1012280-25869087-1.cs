    public class LogicObject
    {
        public LogicObject()
        {
            Collection = new ItemCollection();
            Collection.NextCommand = new RelayCommand(AddItem, CanAddItem);
            AddItem();
        }
        private bool CanAddItem()
        {
            // snip...
        }
        private void AddItem()
        {
            // snip...
        }
    }
