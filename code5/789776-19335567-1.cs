    public class MyProgram{
        
        public static void Main(){
            // Create an instance of this class:
            MyProgram program=new MyProgram();
    
            // And call Method1 on the instance:
            program.Method1();
        }
    
        // Notice how method1 is not static this time:
        public void Method1(){
            Console.WriteLine("Hello!");
        }
    
    }
