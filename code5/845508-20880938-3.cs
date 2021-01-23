    public ClassA
    {
        public event EventHandler SomeEvent;
        private ClassB classB = new ClassB();
        
        public ClassA()
        {
           classB.SomeEvent += ClassB_SomeEvent;
        }
        private void ClassB_SomeEvent(object sender, EventArgs e)
        {
            if (SomeEvent != null)
                SomeEvent(this, e);
        }
    }
