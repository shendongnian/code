    class MyClass:IDisposable
    {
        ClassB _otherClass;
        ...
        ~MyClass()
        {
             //Call Dispose from constructor
             Dispose(false);
        }
        public void Dispose()
        {
            //Call Dispose Explicitly
            Dispose(true);
            //Tell the GC not call our destructor, we already cleaned the object ourselves
            GC.SuppressFinalize(this);
        }
        protected virtual Dispose(bool disposing)
        {
            if (disposing)
            {
                //Clean up MANAGED resources here. These are guaranteed to be INvalid if 
                //Dispose gets called by the constructor
                
                //Clean this if it is an IDisposable
                _otherClass.Dispose();
               //Make sure to release our reference
                _otherClass=null;
            }
            //Clean UNMANAGED resources here
        }
    }
