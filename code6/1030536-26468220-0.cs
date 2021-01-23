    public class Class1
    {
        private bool hasCalledMethod1;
        public Class1()
        {
        }
        public void Method1()
        {
            //user should call this method before Methode2
            hasCalledMethod1 = true;
        }
        public void Method2()
        {
            if (!hasCalledMethod1)
            {
                throw new InvalidOperationException("Must call Method1 before calling Method2");
            }
            //user should call Methode1 before calling this method
        }
    }
