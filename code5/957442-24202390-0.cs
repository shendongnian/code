    public class Foo
    {
        public void A(int myint)
        {
            Console.WriteLine(myint.ToString());
        }
        public void B(int myint1, int myint2)
        {
            Console.WriteLine((myint1 + myint2).ToString());
        }
        public void myQuestionMethod(string parameterMethodName, params object[] parameters)
        {
            var method = this.GetType().GetMethod(parameterMethodName, BindingFlags.Instance | BindingFlags.Public);
            method.Invoke(this, parameters);
        }
    }
    public class Test
    {
        public static void Main()
        {
            var foo = new Foo();
            foo.myQuestionMethod("B", 1, 2);
            Console.Read();
        }
    }
