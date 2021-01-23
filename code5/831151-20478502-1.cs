        public String WrappedMethodA() 
        {
            try {
               return base.MethodA(); // using 'base' as the client object.
            } catch(Exception x) {
               return ""; // or do some other stuff.
            }
        }
