    class ViewModel : DataBase
    {
        private String _prop1;
        public String Prop1
        {
            get { return _prop1; }
            set
            {
                SetField(ref _prop1, value, () => Prop1);
            }
        }
    }
