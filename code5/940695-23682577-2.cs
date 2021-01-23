    public class Parent
    {
        public Child Child {get; set;}
        public string WhateverProperty {get; set;}
    }
    public class Child 
    {
        public Parent Parent {get; set;}
        public string WhateverProperty
        {
            get { return Parent.WhateverProperty; }
            set { Parent.WhateverProperty = value; }
        }
    }
