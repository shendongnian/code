    class AbstractServerToClientMessage {
         public virtual string ToJSON();
    }
    class OnNewObjectMessage: AbstractServerToClientMessage {...}
    class OnSomethingElseHappenedMessage: AbstractServerToClientMessage {...}
    void NotifyClient(AbstractServerToClientMessage message)
    event OnNewObject;
    event OnSomethingElseHappened;
    void notifyAboutNewObjects() {
        ...
        OnNewObject += NotifyClient;
        ...
    }
    void AddNewObject(SomeObject obj) {
        OnNewObjectMessage message(obj);
        OnNewObject(message);
        // actually add the object
    }
