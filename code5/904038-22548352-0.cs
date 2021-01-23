        public class MyClass
        {
            private int age;
            public int persons_age
            {
                get
                {
                    return age;
                }
 
                set
                {
                    if(value > 0)
                        age = value;
                    else
                        //do something here
                }
            }
    
        } 
 
