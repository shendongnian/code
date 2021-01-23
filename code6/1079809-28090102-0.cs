    public class SomeClass
    {
        public Button Button02;
        private void Method111()
        {
            Button Button03;
            // Button03 is accessible because it is declared in this method
            // Button02 is accessible because it is declared in this class
        }
        private void SomeOtherMethd()
        {
            // Button03 is not accessible because it was declared in other method's scope
            // Button02 is accessible because it is declared ned in this class
        }
    }
