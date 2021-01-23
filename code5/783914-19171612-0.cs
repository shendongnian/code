    interface ICommonEvents {
        void OnError(string message, OnErrorEventsArgs.ShowExceptionLevel showException, Exception exception);
        event EventHandler<OnErrorEventsArgs> OnErrorEvent {add;remove;}
    }
    // Keep the implementation the same
    public class CommonEvents : DisposanbleObject, ICommonEvents {
        ...
    }
    // Here is your derived class:
    public class ItemDal : Common.Dal.BaseDal, ICommonEvents {
        private readonly CommonEvents ce = ... // Initialize your common events
        void OnError(string message, OnErrorEventsArgs.ShowExceptionLevel showException, Exception exception) {
            ce.OnError(message, showException, exception);
        }
        event EventHandler<OnErrorEventsArgs> OnErrorEvent {
            add {ce.OnErrorEvent += value;}
            remove {ce.OnErrorEvent -= value;}
        }
    }
