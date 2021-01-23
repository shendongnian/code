    abstract class MybaseClass()
    {
        protected virtual int MyMethodInternal(int a, int b){ //this method is not visible to the outside
         // implementors override this
        }
        
        public sealed int MyMethod(int a, int b){ // users call this method
        var res = MyMethodInternal(a,b);
        if(res < 10)
            throw new Exception("bad implementation!");
        }
    }
