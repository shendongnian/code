    class Out1 { };  // some specific data structure
    class In1 { }   // some specific data structure
    class Out2 { }  // some specific data structure
    class In2 { }   // some specific data structure
    class Out3 { }  // some specific data structure
    class In3 { }
    internal interface IClassWithMethodsToCall
    {
        Out1 GetOut1(In1 inParam);
        Out2 GetOut2(In2 inParam);
        Out3 GetOut3(In3 inParam);
    }
    class ClassWithMethodsToCallImpl: IClassWithMethodsToCall
    {
        public Out1 GetOut1(In1 inParam) { return null; } // would have some spesific implementation 
        public Out2 GetOut2(In2 inParam) { return null; }
        public Out3 GetOut3(In3 inParam) { return null; }
    }
    class ClassWithMethodsToCall: IClassWithMethodsToCall
    {
        private readonly ClassWithMethodsToCallImpl _impl;
        public ClassWithMethodsToCall(ClassWithMethodsToCallImpl impl)
        {
            _impl = impl;
        }
        public Out1 GetOut1(In1 inParam)
        {
            return tryFunc(() => _impl.GetOut1(inParam));
        }
        public Out2 GetOut2(In2 inParam)
        {
            return tryFunc(() => _impl.GetOut2(inParam));
        }
        public Out3 GetOut3(In3 inParam)
        {
            return tryFunc(() => _impl.GetOut3(inParam));
        }
        private static T tryFunc<T>(Func<T> func)
        {
            try
            {
                return func();
            }
            catch (Exception exception)
            {
                // Do something with exception
                throw;
            }
        }
    }
