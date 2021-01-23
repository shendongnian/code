    class MyObject
            {
                private string _title;
                private string _author;
                public MyObject()
                {
    
                }
    
                public String Title
                {
                    get
                    {
                        return _title;
                    }
    
                    set
                    {
                        if (String.IsNullOrWhiteSpace(_title))
                        {
                            _title = value;
                        }
                    }
                }
                public String Author
                {
                    get
                    {
                        return _author;
                    }
    
                    set
                    {
                        if (String.IsNullOrWhiteSpace(_author))
                        {
                            _author = value;
                        }
                    }
                }
    
                // ...
            }
