    public abstract class Base 
    {
        public abstract void Assign ( object value );
    }
    public class Assigner<EventType, ActionType>: Base
    {
        public override void Assign ( object value )
        {
            AssignAction((ActionType)value);
        }
        private void AssignAction ( ActionType action )  
        {
            var event = _eventAggregator.GetEvent<EventType>();
            var token = event.Subscribe(action);
            _compositeEvents.Add(event, token);
        }
    }
