    class SomeClass
    {
        private bool isMyFriend()
        {
            StackTrace st = new StackTrace();
            StackFrame callerSF = st.GetFrame(2);
            MethodBase mb = callerSF.GetMethod();
            Type callerType = mb.DeclaringType;
            // FriendClass is my friend
            if (typeof(FriendClass) == callerType)
                return true;
            else
                return false;
        }
    // ....
