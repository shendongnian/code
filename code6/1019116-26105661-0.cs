      class MyObject
            {
                private string _title;
                private string _author;
                public MyObject(string title, string author)
                {
                    _title = title;
                    _author = author;
                }
    
                public String Title
                {
                    get
                    {
                        return _title;
                    }
                }
                public String Author
                {
                    get
                    {
                        return _author;
                    }
                }
    
                // ...
            }
