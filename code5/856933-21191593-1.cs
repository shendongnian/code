    public partial class Data
        {
            public string AccountNumber { get; set; } // only property left that is mapped to
                                                      // database because the type matches
            public long VisitKey 
            {
                get
                {
                    return Convert.ToInt64(_visitKey);
                }
                set
                {
                    _visitKey = value.ToString();
                }
            }
            public long CodeKey
            {
                get
                {
                    return Convert.ToInt64(_codeKey);
                }
                set
                {
                    _codeKey = value.ToString();
                }
            }
            public short GroupKey
            {
                get
                {
                    return Convert.ToInt16(_groupKey);
                }
                set
                {
                    _groupKey = value.ToString();
                }
            }
            public int GroupVersion
            {
                get
                {
                    return Convert.ToInt32(_groupVersion);
                }
                set
                {
                    _groupVersion = value.ToString();
                }
            }
            public int Classification
            {
                get
                {
                    return Convert.ToInt32(_classification);
                }
                set
                {
                    _classification = value.ToString();
                }
            }
            
            // these fields need to be mapped to the database
            private string _visitKey;
            private string _codeKey;
            private string _groupKey;
            private string _groupVersion;
            private string _classification;
        }
