    public class Test
    {
        static string test = ""; // class member
        
        public void TestTest()
        {
            // if you comment the below declaration out, 
            // then the right "test" will be assigned
            string test = "";  // local member 
            test = "hello"; // the local member is being assigned, not the class member
        }
        public void  GetTest()
        {
            // This will print "test is: [blank]" because the class member 
            // "test" was never assigned to
            Console.WriteLine("Test is:" + test); ;
        }
    }
