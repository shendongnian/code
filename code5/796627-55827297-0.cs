    int ? index = null;
    
    public int Index
            {
                get
                {
                    if (index.HasValue) // Check for value
                        return index.Value; //Return value if index is not "null"
                    else return 777; // If value is "null" return 777 or any other value
                }
                set { index = value; }
            }
