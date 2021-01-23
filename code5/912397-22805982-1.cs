    public class ListHandler
    {
        List<object> ObjectList = new List<object>();
        List<string> StringList = new List<string>();
        List<int> IntList = new List<int>();
        public void Add(object item)
        {
            HandleAdd(item);
        }
        public void Add(string item)
        {
            HandleAdd(item);
        }
        public void Add(int item)
        {
            HandleAdd(item);
        }
        private void HandleAdd(object item)
        {
            ObjectList.Add(item);
        }
        private void HandleAdd(string item)
        {
            StringList.Add(item);
        }
        private void HandleAdd(int item)
        {
            IntList.Add(item);
        }
    }
