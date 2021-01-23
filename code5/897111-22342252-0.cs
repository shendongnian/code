    class MyClass
    {
        private int myVariable;
        public int MyVariable
        {
            get
            {
                return this.myVariable;
            }
            set
            {
                System.Diagnostics.Debug.Print(value.ToString());
                this.myVariable = value;
            }
        }
    }
