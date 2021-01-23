    class MutableStructHolder
    {
        public MutableStruct Field;
    
        private MutableStruct _Property;
        public MutableStruct Property { 
           get { return _Property; }
           set { _Property = value; }
        }
    }
