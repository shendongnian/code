        struct myTimeStruct
        {
            public int minutes
            {
                get { return minutes; }
                set
                {
                    minutes = minutes % 60;
                    hours += minutes / 60;
                }
            }
            private int hours
            {
                get { return hours; }
                set { hours = value; }
            }
        }
