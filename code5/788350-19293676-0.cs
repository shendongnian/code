    public class TypeCollection
    {
        class KeyValue // define your key / value object to store the data
        {
            public string Key
            {
                get;
                set;
            }
            public object Value
            {
                get;
                set;
            }
        }
        private KeyValue[] colType;
        public TypeCollection(object length) // why use object instead of int???
        {
            this.colType = new KeyValue[(int)length];
        }
        public object this[string key]
        {
            get
            {
                for (var i = 0; i < colType.Length; i++) // find the key inside the array
                {
                    if (colType[i].Key == key)
                    {
                        return colType[i].Value;
                    }
                }
                return null;
            }
            set
            {
                // this should add new elements so you have to resize the array etc.
                for (var i = 0; i < colType.Length; i++)
                {
                    if (colType[i].Key == key)
                    {
                        colType[i].Value = value;
                        return;
                    }
                }
            }
        }
    }
