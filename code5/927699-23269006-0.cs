    namespace CL.Forms
    {
        public partial class A
        {
            public StringBuilder sb = new StringBuilder();
 
           //Constructor to set default for string builder
            public A()
            {
                sb.Append("a");
                sb.Append("b");
            }
        }
  
        public class B
        {
            public B()
            {
                A objA=new A();
                string s= objA.sb.ToString();
            }
       }
