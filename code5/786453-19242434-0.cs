    namespace WindowsFormsApplication
    {
        using System;
        using System.Windows.Forms;
    
        public partial class Form2 : Form
        {
            public EventHandler<MyEventArgs> MyEventHandler;
    
            public Form2()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                var eventArgs = new MyEventArgs()
                {
                    TriggeredDateTime = DateTime.UtcNow,
                    Value = 5
                };
    
                OnMyEventHandler(eventArgs);
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                var eventArgs = new MyEventArgs()
                {
                    TriggeredDateTime = DateTime.UtcNow,
                    Value = 10
                };
    
                OnMyEventHandler(eventArgs);
            }
    
            private void OnMyEventHandler(MyEventArgs args)
            {
                var handler = MyEventHandler;
                if (handler != null)
                {
                    handler(this, args);
                }
            }
        }
    
        public class MyEventArgs
        {
            public DateTime TriggeredDateTime { get; set; }
            public int Value { get; set; }
        }
    }
