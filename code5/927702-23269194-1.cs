    namespace CL.Forms
    {
        public partial class A
        {
            //decalring sb
            public StringBuilder sb = new StringBuilder();
            //giving sb default values incase you dont change it just call the variable but it has
            //but it has to happen in a method
            public A()
            {
                sb.Append("a");
                sb.Append("b");
            }
            // a seperate methode to return sb
            public StringBuilder getSb()
            {
                return sb;
            }
        }
        public static class B
        {
            //same stuff
            A objA = new A();
            public void methodNameHere()
            {
                string s = objA.sb.ToString();
            }
        }
    }
