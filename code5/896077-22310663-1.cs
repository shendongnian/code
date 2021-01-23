    public class MyClass
    {
        public static event EventHandler<IndexCalledEventArgs> IndexCalled;
        public ActionResult Index()
        {
            int index;
            // Somehow get an index
            index = 7;
            OnIndexCalled(this, index);
            return new ActionResult { Index = index };
        }
        private static void OnIndexCalled(MyClass sender, int index)
        {
            var handler = IndexCalled;
            if (handler != null) {
                // Create the event args and fire the event.
                handler(sender, new IndexCalledEventArgs(index));
            }
        }
    }
