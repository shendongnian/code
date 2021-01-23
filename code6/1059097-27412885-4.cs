    partial class Form3 : Form
    {
        public event EventHandler IncrementProgress;
        void SomeMethodWhereProgressHappens()
        {
            // ... make some progress
            // Then raise the progress event
            EventHandler handler = IncrementProgress;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
            // ... then make some more progress, etc.
        }
    }
