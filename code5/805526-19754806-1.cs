    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Reactive;
    using System.Reactive.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public class UpdateEventArgs : EventArgs
        {
            public string Value { get; set; }
        }
        public interface ITask
        {
            event EventHandler<EventArgs> Completed;
            event EventHandler<UpdateEventArgs> Update;
        }
    
        public partial class Form1 : Form, ITask
        {
            public event EventHandler<EventArgs> Completed;
    
            public event EventHandler<UpdateEventArgs> Update;
    
            private Timer m_timer = new Timer();
    
            private int m_timercount = 5;
    
            public Form1()
            {
                InitializeComponent();
    
                var obUpdate = Observable.FromEventPattern<UpdateEventArgs>(this, "Update");
                var obCompleted = Observable.FromEventPattern<EventArgs>(this, "Completed");
    
                var obUpdatesUntilCompletedSequence = obUpdate.TakeUntil(obCompleted);
    
                obUpdatesUntilCompletedSequence.Subscribe(new Action<EventPattern<UpdateEventArgs>>(UpdateOccurred), new Action(UpdateCompleted));
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                m_timer.Interval = 1000;
                m_timer.Start();
                m_timer.Tick += m_timer_Tick;
            }
            
            void m_timer_Tick(object sender, EventArgs e)
            {
                Update(this, new UpdateEventArgs { Value = DateTime.Now.ToString() });
    
                if (--m_timercount == 0)
                {
                    Completed(this, new EventArgs());
    
                    m_timer.Stop();
                }
            }
    
            private void UpdateOccurred(EventPattern<UpdateEventArgs> update)
            {
                System.Diagnostics.Debug.WriteLine(update.EventArgs.Value);
            }
    
            private void UpdateCompleted()
            {
                System.Diagnostics.Debug.WriteLine("No more updated will be received");
            }
        }
    }
