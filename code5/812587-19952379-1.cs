    public abstract class AbsObserver
    {
        protected MyForm Form;
        public AbsObserver(Subject subject)
        {
            subject.Attach(OnNotify);
            Form = new MyForm();
            Form.btn1Clicked += Form_btn1Clicked;
        }
        void Form_btn1Clicked()
        {
            Console.WriteLine("Do button click task");
        }
        public abstract void OnNotify();
    }
    public class MyForm : Form
    {
        public event Action btn1Clicked;
        private void button1_Click(object sender, EventArgs e)
        {
            btn1Clicked();
        }
    }
    public class Observer1 : AbsObserver
    {
        public Observer1(Subject subject)
            : base(subject)
        {
        }
        public override void OnNotify()
        {
            Console.WriteLine("observer1 notified");
        }
    }
    public class Observer2 : AbsObserver
    {
        public Observer2(Subject subject)
            : base(subject)
        {
        }
        public override void OnNotify()
        {
            Console.WriteLine("observer2 notified");
        }
    }
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
