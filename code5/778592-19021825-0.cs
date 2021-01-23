    public class MyClass   {
        
        MyClass me  = null;
      
        //private CTOR 
        private MyClass  () {
        }
    
        public static MyClass  ConstructMe(..parameters..) {
             if(me != null) 
                return me;
             me = new MyClass();
             ....setup parameters .... 
             return me,
        }
    
    }
