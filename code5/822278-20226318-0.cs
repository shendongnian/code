    namespace titi
    {
        public class testbed
        {
            testbed()
            {
                c1 o1 = new c1();                   //works
                test.sub.c2 o2 = new test.sub.c2(); //works
                sub.c2 o3 = new sub.c2();           //don't work
            }
        }
    }
