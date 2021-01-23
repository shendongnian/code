        public void DoStuff(IMyInterface myObject)
        {
            myObject.InterfaceMethod();
        }
        public void OtherMethod<T>(T myObject)
            where T : class
        {
            if (myObject is IMyInterface) // have ascertained that T is IMyInterface
            {
                DoStuff((IMyInterface)myObject);
            }
        }
