      public enum Qwerty
        {
            Q,W,E,R,T,Y
        }
    
      class A
        {
            private int[,] _array=new int[10,10];
    
            public B PropertyB { get; set; }
    
            public int this[int i, int j]
            {
                get { return _array[i, j]; }
                set { _array[i, j] = value; }
            }
        }
    
        class B
        {
            public int Value { get; set; }
        }
