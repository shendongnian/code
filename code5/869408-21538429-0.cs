    public class SetOperation  : Form
    {
        private Label label;
        public SetOperation(Task<string> prepWork)
        {
            prepWork.ContinueWith(t =>
            {
                label.Text = t.Result;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
