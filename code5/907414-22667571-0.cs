    public class ViewModelLocator
    {
        ....
        private static List<IMyInterface> _myInterfaces;
        public static List<IMyInterface> MyInterfaces
        {
            get
            {
                return _myInterfaces;
            }
            set
            {
                // So that it will be readonly. Technically unnecessary, but may be good
                // practice.
                if(_myInterfaces != null) return;
                _myInterfaces = value;
            }
        }
    }
