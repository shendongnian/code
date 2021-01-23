        public class Trigger
        {
            public event Action TriggerEvent;
            public void NotifyTrigger()
            {
                this.TriggerEvent();
            }
        }
        public class Parent
        {
            public Trigger _trigger;
            public Trigger Trigger
            {
                get
                {
                    return _trigger;
                }
                set
                {
                    _trigger = value;
                    _trigger.TriggerEvent += this.OnTrigger;
                }
            }
            internal virtual void OnTrigger()
            {
                Debug.WriteLine("I don't want to write this!");
            }
        }
        public class Child : Parent
        {
            internal override void OnTrigger()
            {
                Debug.WriteLine("I want this to be written, but it's not.");
            }
        }
        [Test]
        public void testetst() // Or Main
        {
            Child c = new Child();
            c.Trigger = new Trigger();
            c.Trigger.NotifyTrigger();
        }
