        [TestMethod]
        public void Test5()
        {
            const string path = @"C:\test";
            var mocker = new AutoMoqer();
            var watcherMock = mocker.GetMock<AbstractTest>();
            var instance = mocker.Create<Tester>();
            
            instance.Run(path);
            watcherMock.VerifySet(x => x.Path = path);
        }
