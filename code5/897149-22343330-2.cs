    namespace UniversityAssembly
    {
        using System;
        public class RealClass
        {
            Random rand = new Random();
            public int SomeProperty { get { return rand.Next(); } }
            public string SomeMethod()
            {
                return "We used real library! Meow!";
            }
        }
    }
