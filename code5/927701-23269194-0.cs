    namespace CL.Forms
    {
        public partial class A
        {
            public StringBuilder sb = new StringBuilder();
            public A()
            {
                sb.Append("a");
                sb.Append("b");
            }
            public StringBuilder getSb()
            {
                return sb;
            }
        }
        public static class B
        {
            A objA = new A();
            public void methodNameHere()
            {
                string s = objA.sb.ToString();
            }
        }
    }
