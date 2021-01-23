    public class VisibilityProperty : PropertyInfo
    {
        private int _index;
        public VisibilityProperty(int index)
        {
            _index = index;
        }
        public override string Name
        {
            get { return "V" + _index; }
        }
        public override object GetValue(object obj, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture)
        {
            var host = obj as VisibilitiesClass;
            return host[_index];
        }
    }
