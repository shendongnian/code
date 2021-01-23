    public partial class TestWindow : Window
        {
            public TestWindow()
            {
                this.InitializeComponent();
                //don't publish event in constructor, since the event yet to have any subscriber
                //this.TestEvent(this, new EventArgs());
            }
            public void DoSomething()
            {
                //Do Something Here and notify subscribers that something has been done
                if (TestEvent != null)
                {
                    TestEvent(this, new EventArgs());
                }
            }
            public delegate void TestDelegate(object sender, EventArgs e);
            public event TestDelegate TestEvent;
        }
        public class Subscriber
        {
            public Subscriber(TestWindow win)
            {
                win.TestEvent += this.TestMethod;
            }
            private void TestMethod(object sender, EventArgs e)
            {
                //Do something when the event occurs
            }
        }
