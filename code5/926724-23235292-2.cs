    class MutableStructHolder
    {
        public MutableStruct Field;
    
        private MutableStruct _Property;
        public MutableStruct getProperty() { 
           return _Property;
        }
        public void setProperty(MutableStruct value) { 
           _Property = value;
        }
    }
