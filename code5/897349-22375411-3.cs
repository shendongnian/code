        [Fact]
        public void InterceptorTest()
        {
            var kernel = new StandardKernel();
            kernel.Load<DemoModule>();
            kernel.Get<IClassNotToBeIntercepted>()
                .DoSomething();
            kernel.Get<IClassToBeIntercepted>()
                .LogThis();
        }
