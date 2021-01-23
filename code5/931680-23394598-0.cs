        public MyClass
        {
            private readonly ILib _lib; 
            
            public Class2(ILib lib)
            {
              _lib = lib
            }
            public MyMethod()
            {
                _lib.DoStuff();
            }                
        }
