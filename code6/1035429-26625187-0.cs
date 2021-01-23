    class Test
    {
        string name;
        Test childTest;
        public Test(string name)
        {
            this.name = name;
            this.childTest = null;
        }
        public Test(string name, Test test)
        {
            this.name = name;
            this.childTest = test;
        }
    }
    Test a = new Test("a", new Test("b", new Test("c")));
