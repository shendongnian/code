            private string name;
            public string Name
            {
                get 
                {
                    return name; 
                }
                set 
                {
                    if (value != null)
                        name = value.Trim();
                    else
                        name = null;
                }
            }
