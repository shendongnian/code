        public foo(Guid guid)
        {
            //some code here
        }
        public foo(Guid guid, bool myBool,bool fooclass = true)
        {
            
            if (fooclass)
            {
                //some other code here
            }
            
        }
        //Here I have a bunch of method/properties
        public void GenX(bool french, int width)
        {
            //my method implementation
        }
    }
    class bar : foo
    {
        public bar(Guid guid, bool myBool,bool barclass = true) : base(guid,myBool,false)
        {
            //some code here
        }
        new public void GenX(bool french, int width)
        {
            //my new method implementation
        }
    }
