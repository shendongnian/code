        [Test]
        public void TestIncludeByType()
        {
            var sut = new AtoD();
            Asserter assert;
            assert = TestHelper.CreateShortAsserter();
            assert.PrintEquals("new AtoD() { A = 1 B = 2 C = 3 D = 4 }", sut);
            assert = TestHelper.CreateShortAsserter();
            assert.Project.IncludeByType<AtoD, IA>();
            assert.PrintEquals("new AtoD() { A = 1 }", sut);
            assert = TestHelper.CreateShortAsserter();
            assert.Project.IncludeByType<AtoD, IA, IB>();
            assert.PrintEquals("new AtoD() { A = 1 B = 2 }", sut);
            assert = TestHelper.CreateShortAsserter();
            assert.Project.IncludeByType<AtoD, IA, IB, IC>();
            assert.PrintEquals("new AtoD() { A = 1 B = 2 C = 3 }", sut);
            assert = TestHelper.CreateShortAsserter();
            assert.Project.IncludeByType<AtoD, IA, IB, IC, ID>();
            assert.PrintEquals("new AtoD() { A = 1 B = 2 C = 3 D = 4 }", sut);
        }
        [Test]
        public void TestExcludeByType()
        {
            var sut = new AtoD();
            Asserter assert;
            assert = TestHelper.CreateShortAsserter();
            assert.PrintEquals("new AtoD() { A = 1 B = 2 C = 3 D = 4 }", sut);
            assert = TestHelper.CreateShortAsserter();
            assert.Project.ExcludeByType<AtoD, IA>();
            assert.PrintEquals("new AtoD() { B = 2 C = 3 D = 4 }", sut);
            assert = TestHelper.CreateShortAsserter();
            assert.Project.ExcludeByType<AtoD, IA, IB>();
            assert.PrintEquals("new AtoD() { C = 3 D = 4 }", sut);
            assert = TestHelper.CreateShortAsserter();
            assert.Project.ExcludeByType<AtoD, IA, IB, IC>();
            assert.PrintEquals("new AtoD() { D = 4 }", sut);
            assert = TestHelper.CreateShortAsserter();
            assert.Project.ExcludeByType<AtoD, IA, IB, IC, ID>();
            assert.PrintEquals("new AtoD() { }", sut);
        }
