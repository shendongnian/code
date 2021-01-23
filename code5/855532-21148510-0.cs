    public class RepeatButton : Button
    {
        readonly Timer timer = new Timer();
        public event EventHandler Depressed;
        public virtual TimeSpan Interval
        {
            get { return TimeSpan.FromMilliseconds(timer.Interval); }
            set { timer.Interval = (int)value.TotalMilliseconds; }
        }
        
        public RepeatButton()
        {
            timer.Interval = 100;
            timer.Tick += delegate { OnDepressed(); };
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            timer.Stop();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            timer.Start();
        }
        protected virtual void OnDepressed()
        {
            var handler = this.Depressed;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
    }
