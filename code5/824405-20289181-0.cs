    class BaseClass
    {
        public BaseClass()
        {
            StackTrace st = new StackTrace();
            string child = st.GetFrame(1).GetMethod().DeclaringType.Name;
            // ...
        }
    }
