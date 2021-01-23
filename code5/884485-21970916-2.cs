        [TestMethod]
        public void Test()
        {
            const string path = @"C:\test";
            var watcherMock = new Mock<FileSystemWatcherBase>();
            watcherMock.Object.Path = path;
            watcherMock.VerifySet(x => x.Path = path);
        }
        [TestMethod]
        public void Test2()
        {
            const string path = @"C:\test";
            var mocker = new AutoMoqer();
            var instance = mocker.Create<Tester>();
            var watcherMock = mocker.GetMock<AbstractTest>();
            watcherMock.Object.Path = path;
            watcherMock.VerifySet(x => x.Path = path);
        }
        [TestMethod]
        public void Test3()
        {
            const string path = @"C:\test";
            var mocker = new AutoMoqer();
            var instance = mocker.Create<Tester>();
            var watcherMock = mocker.GetMock<AbstractTest>();
            instance.Run(path);
            watcherMock.VerifySet(x => x.Path = path);
        }
        [TestMethod]
        public void Test4()
        {
            const string path = @"C:\test";
            var testMock = _mocker.GetMock<AbstractTest>();
            var tester = new Tester(testMock.Object);
            tester.Run(path);
            testMock.VerifySet(x => x.Path = path);
        }
        public abstract class AbstractTest
        {
            public abstract string Path { get; set; }
        }
        public class Tester
        {
            private readonly AbstractTest _test;
            public Tester(AbstractTest test)
            {
                _test = test;
            }
            public void Run(string path)
            {
                _test.Path = path;
            }
        }
