            public TestContext TestContext
            {
                get
                {
                    return testContextInstance;
                }
                set
                {
                    base.TestContext = value;
                    testContextInstance = value;
                }
            }
            private TestContext testContextInstance;
