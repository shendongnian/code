    public Interface IObserver
    {
        public void OnNotify(CommonNotification Notification);
    }
    ....
    
    public class MyForm:Form, IObserver {
    ....
    }
