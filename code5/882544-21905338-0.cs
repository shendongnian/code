    public class CustomDictionary : Dictionary<int, object>
        {
            public object this[int index]
            {
                get
                {
                    if (this.Count <= index)
                    {
                        return null;
                    }
                    else
                    {
                        return this[index];
                    }
                }
                set
                {
                    if (this.Count <= index)
                    {
                    }
                    else
                    {
                        this[index] = value;
                    }
                }
            }
        }
