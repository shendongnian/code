    public class A
    {
        protected const string constString = "Test";          //Allowed
        protected readonly string readonlyString = "Test";    //Allowed
    
        public A(){
          constString = "Test";      //Not allowed
          readonlyString = "Test";   //Allowed
        } 
    }
    
    public class B: A
    {
        public B(){
          constString = "Test";      //Not allowed
          readonlyString = "Test";   //Not allowed
        }
    }
