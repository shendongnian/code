    public class SomeClass 
    {
        private EventDisabler _eventDisabler;
        ...
        public void ToggleEventDisabler(bool eventDisablerOn)
        {
            _eventDisabler = eventDisablerOn ? new EventDisabler() : null;
        }
        public void Foo() 
        {
            ToggleEventDisabler(true); //turn on the event disabler
            ...do stuff...
        }
        public void Bar() 
        {
            ...do stuff...
         
            if (_eventDisabler != null) 
            {
                _eventDisabler.Dispose();
            }
        }
    }
