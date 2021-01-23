        [ExceptionLogger(AspectPriority = 1)]
        [NullCheck(AspectPriority = 2)]
        private void TestMethod(string s)
        {
            Console.WriteLine(s);
        }
