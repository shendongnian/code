            [TestMethod] // place only on the list--not the individuals
            public void OrderedStepsTest()
            {
                OrderedTest.Run(TestContext, new List<OrderedTest>
                {
                    new OrderedTest ( T10_Reset_Database, false ),
                    new OrderedTest ( T20_LoginUser1, false ),
                    new OrderedTest ( T30_DoLoginUser1Task2, true ), // continue on failure
                    new OrderedTest ( T30_DoLoginUser1Task2, true ), // continue on failure
                    // ...
                });                
            }
