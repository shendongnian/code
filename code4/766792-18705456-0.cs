    public class SomeBaseClassWithAnEvent
    {
        public event EventHandler SomeEvent;
    
        protected virtual void OnSomeEvent()
        {
            var handler = SomeEvent;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    
        public void SomeOtherMethodThatHasSideEvents()
        {
            //...do stuff...
            OnSomeEvent();
            //...do more stuff...
        }
    }
    
    public class SomeSubclass : SomeBaseClassWithAnEvent
    {
        protected override void OnSomeEvent()
        {
            // custom stuff here to do it before the event
            base.OnSomeEvent();
            // or here to do it after the event
        }
    }
