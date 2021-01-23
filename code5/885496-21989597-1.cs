    public class MyBaseClass
    {
        public void doMyWork()
        {
            new MySubClass1().doSubClass1();
            new MySubClass2().doSubClass2();
        }
    
        private class MySubClass1
        {
            public void doSubClass1()
            {
                //Do stuff
            }
        }
        
        private class MySubClass2
        {
            public void doSubClass2()
            {
                //Do stuff
            }
        }
    
    }
