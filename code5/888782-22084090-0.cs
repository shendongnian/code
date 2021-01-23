    public delegate int Contacts(int a, int b);
    
        public static class TestClass
        {
            public static void Test()
            {            
                Contacts contactsFunc = (Contacts)((a, b) => a + b);
                contactsFunc(2, 3);
                //less verbose mode
                ((Contacts)((a, b) => a + b))(2,3);
            }
        }
