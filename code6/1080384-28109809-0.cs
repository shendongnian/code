        public void Operation(IEnumerable<TestClass> samples, Func<IEnumerable<double>, double> operation)
        {
            var foo = samples.MapReduce(s => s.Foo, operation);
            var bar = samples.MapReduce(s => s.Bar, operation);
        }
