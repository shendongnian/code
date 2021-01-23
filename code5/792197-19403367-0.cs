    // These are "import" statements used to refer to other namespaces.
    using System;
    // This is a namespace declaration, used to group related classes together.
    // As far as I know, in Unity you don't use these.
    namespace YourNamespace
    {
        // Class definition: defining a new custom object type.
        public class Person
        {
            // Field: defining a new internal data element
            public string name;
            // Constructor that takes no arguments. 
            public Person()
            {
                name = "unknown";
            }
            // Method: defining a new behavior for your class.
            public void SetName(string newName)
            {
                name = newName;
            }
        }
    }
