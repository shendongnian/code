    private class SomeClass
    {
        private string field;
        private int count;
        public SomeClass()
        {
            MethodA();
            MethodB();
        }
        private void MethodA()
        {
            field = "Something";
        }
        private void MethodB()
        {
            count = field.Length;
        }
    }
