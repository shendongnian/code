    public class Subject
    {
        private event Action Notify;
        public void Attach(Action a)
        {
            Notify += a;
        }
        private void NotifyAll()
        {
            Notify();
        }
    }
    public abstract class AbsObserver
    {
        public AbsObserver(Subject subject)
        {
            subject.Attach(OnNotify);
        }
        public abstract void OnNotify();
    }
    public class Observer1:AbsObserver
    {
        public Observer1(Subject subject) : base(subject)
        {
        }
        
        public override void OnNotify()
        {
            Console.WriteLine("observer1 notified");
        }
    }
    public class Observer2:AbsObserver
    {
        public Observer2(Subject subject) : base(subject)
        {
        }
        public override void OnNotify()
        {
            Console.WriteLine("observer2 notified");            
        }
    }
