    public class MyCollectionEditor : CollectionEditor // needs a reference to System.Design
    {
        public MyCollectionEditor(Type type)
            : base(type)
        {
        }
        protected override string GetDisplayText(object value)
        {
            // force ToString() usage, but
            // you also could implement some custom logic here
            return string.Format("{0}", value);
        }
    }
