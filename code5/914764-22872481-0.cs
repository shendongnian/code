    public class MyItem : IDataErrorInfo
        {
            private string name;
     
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
     
            public string Error
            {
                get
                {
                    return null;
                }
            }
     
            public string this[string name]
            {
                get
                {
                    string result = null;
     
                    if (name == "Name")
                    {
                        if (string.IsNullOrEmpty(Name))
                        {
                            result = "Name must be specified.";
                        }
                    }
                    return result;
                }
            }
        }
