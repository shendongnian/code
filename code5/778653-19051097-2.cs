    using System;
    using NUnit.Framework;
    using SharpTestsEx;
    
    namespace StackOverflowExample.Moq
    {
        public interface ISource
        {
            event Action<ISource> DataChanged;
            int InvokationCount { get; set; }
        }
    
        public class ClassToTest
        {
            public void DoWork(ISource source)
            {
                source.DataChanged += this.EventHanler;
            }
    
            private void EventHanler(ISource source)
            {
                source.InvokationCount++;
                source.DataChanged -= this.EventHanler;
            }
        }
    
        [TestFixture]
        public class EventUnsubscribeTests
        {
            private class TestEventSource :ISource
            {
                public event Action<ISource> DataChanged;
                public int InvokationCount { get; set; }
                
                public void InvokeEvent()
                {
                    if (DataChanged != null)
                    {
                        DataChanged(this);
                    }
                }
                
                public bool IsEventDetached()
                {
                    return DataChanged == null;
                }
            }
    
            [Test]
            public void DoWork_should_detach_from_event_after_first_invocation()
            {
                //arrange
                var testSource = new TestEventSource();
                var sut = new ClassToTest();
                sut.DoWork(testSource);
    
                //act
                testSource.InvokeEvent();
                testSource.InvokeEvent(); //call two times :)
    
                //assert
                testSource.InvokationCount.Should("have hooked the event").Be(1);
                testSource.IsEventDetached().Should("have unhooked the event").Be.True();
            }
        }
    } 
