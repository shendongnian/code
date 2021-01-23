    public class ClassA
    {
        private ClassB classB = new ClassB();
        public event EventHandler SomeEvent
        {
            add
            {
                classB.SomeEvent += value;
            }
            remove
            {
                classB.SomeEvent -= value;
            }
        }
    }
