    public class InteresedInIndexCalledEvent
    {
        public InteresedInIndexCalledEvent()
        {
            MyClass.IndexCalled += MyClass_IndexCalled;
        }
        void MyClass_IndexCalled(object sender, IndexCalledEventArgs e)
        {
            Console.WriteLine("Index {0} was called", e.Index);
        }
    }
