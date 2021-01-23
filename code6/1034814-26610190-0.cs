    public class A
    {
        private string _createdBy;
        public void SomeAction()
        {
          Console.WriteLine("I was declared in class [{0}]", _createdBy);
        }
        public A()
        {
          var stackFrame = new StackFrame(1);
          var method = stackFrame.GetMethod();
          _createdBy = method.DeclaringType.Name;
        }
    }
