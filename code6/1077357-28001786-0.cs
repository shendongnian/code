    [TestMethod]
    public void FunctionExtention_CombinePredicates_Should_Avoid_Closure()
    {
            var value = 0;
            var copy = value;
            var predicates = new Predicate<int>[]
            {
                x => x > copy
            };
    
            var result = FunctionExtentions.CombinePredicates(predicates);
            value = 1000;
            Assert.IsTrue(result(2));
    }
