    public class VMBase
    {
        public int Add(int a, int b)
        {
            Console.WriteLine("Base class method invoked");
            return a + b;
        }
    }
    public class MyVMBase : VMBase
    {       
        public long Add(long a , long b)
        {
            Console.WriteLine("Derived class method invoked");
            return a + b;
        }    
    }
    public static void Main()
    {           
       MyVMBase myObj = new MyVMBase();
       int imy = 5;
       int j = 6;
       int myaddValue = myObj.Add(imy, j); //COMPILE TIME ERROR Cannot implicitly convert type 'long' to 'int'. An explicit conversion exists (are you missing a cast?)	
       long myaddValue2 = myObj.Add(imy, j);  // NO ERROR
     }  
