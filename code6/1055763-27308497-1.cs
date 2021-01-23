        [TestMethod]
        public void Statement_1()
        {
            SyntaxTreeWriter.Write("Task.Run<string>(() => f(token), token)");
        }
        [TestMethod]
        public void Statement_2()
        {
            SyntaxTreeWriter.Write("Task.Run<string>(() => uc.ViewModel.SlowProcess(token), token)");
        }
        [TestMethod]
        public void Statement_3()
        {
            SyntaxTreeWriter.Write("Task.Run<string>(f(token), token)");
        }
