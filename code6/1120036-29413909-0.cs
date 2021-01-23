    public class Form1 : Form
    {
        public void main()
        {
            //Create thread referencing other class
            TestClass test = new TestClass();
            Thread testThread = new Thread(test.runFunction)
            test.TestThread = testThread;
            //Start the thread
            testThread.Start();
        }//Main End
    }//Form1 Class End
    public class TestClass
    {
        public Thread TestThread { get; set; }
        public void runFunction()
        {
            //Check if the thread is active
            if (TestThread != null && TestThread.isAlive == true)
            {
                //Do things
            }//If End
        }//runFunction End
    }//testClass End
