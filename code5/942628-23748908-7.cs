    public class VisibilitiesType : Type
    {
        private int _count;
        public VisibilitiesType(int count)
        {
            _count = count;
        }
        public override PropertyInfo[] GetProperties(BindingFlags bindingAttr)
        {
            return Enumerable.Range(1, _count).Select(i => new VisibilityProperty(i)).ToArray();
        }
    }
