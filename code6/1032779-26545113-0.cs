    public class CommandQueued
        {
            protected virtual void onHandleCommandMessage(Message msg)
            {
                //onConferenceEvent(msg);
            }
        }
    
        public class DerivedCommandQueue : CommandQueued
        {
            protected override void onHandleCommandMessage(Message msg)
            {
                //..
            }
        }
