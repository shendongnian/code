    class Test
    {
        public Action Yaser;        // instance declaration
        public delegate void Mhd(); // type declaration
        public Mhd myMhd;           // instance declaration
        public Test()
        {
            // instantiation
            this.myMhd = new Mhd(this.SomeMethod);
        }
        private void SomeMethod()
        {
            // your implementation
        }
    }
