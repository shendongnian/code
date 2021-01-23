    class MyClass
    {
        private string Field1;
        private int Field2;
    
        private MyClass()
        {
            
        }
        public MyClass GetMyClassInstance(string Field1=string.Empty, int Field2=-1)
        {
            this.Field1 = Field1;
            this.Field2 = Field2;
        }
    }
