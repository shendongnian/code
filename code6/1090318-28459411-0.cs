        public interface IMyInterface
        {
            event EventHandler OnSomethingHappened;
        }
        //implement the interface
        public class MyBaseClass : IMyInterface
        {
            public event EventHandler OnSomethingHappened;
    
            public void DoSomeLogicWhichRaisesTheEvent()
            {
                if (OnSomethingHappened != null)
                {
                    MyBaseClass sender = this;
                    var eventArgs = new EventArgs();
                    //let all subscibers to event know that the event happened
                    OnSomethingHappened(sender, eventArgs);
                }
            }
        }
    
        public class ConsumerClass
        {
            private IMyInterface myBaseClassInstance;
    
            public ConsumerClass()
            {
                myBaseClassInstance = new MyBaseClass();
                //attach to the event
                myBaseClassInstance.OnSomethingHappened += MyBaseClassInstance_OnSomethingHappened;
            }
    
            private void MyBaseClassInstance_OnSomethingHappened(object sender, EventArgs e)
            {
                //react to the raised event
                throw new NotImplementedException();
            }
        }
