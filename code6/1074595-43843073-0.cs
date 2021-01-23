            As per me, when you want to return 
    or get many things from a single method, 
    better make its return type as CLASS 
    but if you intend to use Tuple which itself is Class then for better naming this new class should inherit from Tuple. e.g. mentioned below.
            
            public CustomReturn ExecuteTask( int a, string b, bool c, object d )
            {
            // Calling constructor of CustomReturn Class to set and get values
              return new CustomReturn(a,b,c,d);
            }
            
            internal class CustomReturn 
            // for tuple inherit from Tuple<int,string,bool,object,double>
            { 
              //for tuple public int A{ get {this.Item1} private set;}
            
              public int A{get;private set;}
              public string B{get;private set;}
              public bool C{get;private set;}
              public object D{get;private set;}
              
              public CustomReturn (int a, string b, bool c, object d )
                  // use this line for tuple ": base( obj, boolean )"
                {
                  this.A = a;
                  this.B = b;
                  this.C = c;
                  this.D = d;
                }
             
            }
        
        Main(args)
        {
          var result = ExecuteTask( 10, "s", true, "object" );
          // now if u have inherited Tuple for CustomReturn class then 
        
          // on doing result. you will get your custom name as A,B,C,D for //Item1,Item2,Item3,Item4 respectively also these Item1,Item2,Item3,Item4 will also be there.
        }
