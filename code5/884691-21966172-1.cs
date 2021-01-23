    struct A
    {
        int x;
        public A(int _x) { x = _x; }
        public int Y
        {
            get
            {
                Random r = new Random();
                return r.Next(0, 1000);
            }
        }
    
    
           public override bool Equals(object obj) 
           {
              //compare whatever you want...
        
           }
        
        }
    }
