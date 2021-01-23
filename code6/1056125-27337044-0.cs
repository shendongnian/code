        public class SimpleClass : SimpleClassPostBack
        {
            public String Label { get; set; }
            public SimpleClass()
            {
                // simulate default loading
                Label = "My Label";
                FirstName = "Rob";
            }
        }
        // contains only editable by the user fields
        public class SimpleClassPostBack
        {
            public String FirstName { get; set; }
        }
