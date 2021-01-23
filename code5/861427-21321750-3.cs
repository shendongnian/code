    public partial class mainForm : Form
    {
        ....//initialize some stuff
        public class mainForm()
        {
            ...
            // not sure where you're instantiating `copy` - you may have to move this
            copy.ProcessExited += (s, a) =>
                button1.Invoke(new Action(() => button1.Enabled = true));
            ...
        }
        private void TimerEventProcessor(object sender, EventArgs e)
        {
            copy.GetNewCopy();
        }
    }
