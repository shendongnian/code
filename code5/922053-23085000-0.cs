     class B : A
        {
            public B(int sharedvalue):base(sharedValue)
            {
                Console.WriteLine("B");
            }
        }
        class A
        {
         private  int _sharedValue;  
            public A(int sharedValue)
            {  // if you have a lot of check to do here it will be best to call the default constructor 
                  _sharedValue = sharedValue; 
                Console.WriteLine("A");
            }
          property int SharedProp
        { get{return _sharedValue;} }
          
        }
        class test
        {
            static void Main()
            { 
                int val = 5 ; 
              
                A b = new B(val);
                Console.WriteLine(A.SharedProp);
        
            }
        }
