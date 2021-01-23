        class TestForNumbers
        {
            private string _ThisIsAField; // a plain old variable at the class level is a field.
    
            public string ThisIsAnAutomaticProperty { get; set; } //this is a typing shortcut, you dont need a backing field.
    
            private string _ThisIsAPropertyBackingField; //another field, but this value is exposed via the property
    
            public string ThisIsAProperty
            {
                get { return _ThisIsAPropertyBackingField; }
                set { _ThisIsAPropertyBackingField = value; } //omit this line if you dont want callers to set the value.
            }
    
        }
    
        class Program
        {
            static void Main()
            {
                var tfn = new TestForNumbers();
                tfn.ThisIsAProperty = "new Value";
                tfn.ThisIsAnAutomaticProperty = "Another new value";
                //tfn._ThisIsAField = "Doesnt Work";
            }
        }
