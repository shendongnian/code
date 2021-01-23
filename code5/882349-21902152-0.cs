    interface Test  
    {  
        void wish();  
    }
    class MyTest : Test
    {  
        public void wish()
        {  
            System.out.println("output: hello how r u");  
        }  
    }
  
    static class Program
    {  
        [STAThread]
        static void main()  
        {  
            Test t=new MyTest();  
            t.wish();  
        }  
    }  
