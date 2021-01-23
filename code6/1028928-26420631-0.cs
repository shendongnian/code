    public class Tests : ReactiveTest
    {
        [Fact]
        public void FactMethodName2()
        {
            var mockedTmp = new Mock<ITmp>();
            var testScheduler = new TestScheduler();
            var temp = new SomeClass2(mockedTmp.Object, testScheduler);
            const int c = 1;
            
            var eventArgs1 = new MyEventArgs(1);
            var eventArgs2 = new MyEventArgs(2);
    
            var results = testScheduler.CreateObserver<MyEventArgs>();
    
            temp.Raw().Select(ep => ep.EventArgs).Subscribe(results);
    
            testScheduler.Schedule(TimeSpan.FromTicks(1000),
                () => mockedTmp.Raise(tmp => tmp.tmpEvent += null, eventArgs1));
            testScheduler.Schedule(TimeSpan.FromTicks(2000),
                () => mockedTmp.Raise(tmp => tmp.tmpEvent += null, eventArgs2));
    
            testScheduler.Start();
    
            results.Messages.AssertEqual(
                OnNext(1000 + c, eventArgs1),
                OnNext(2000 + c, eventArgs2));
        }
    }
