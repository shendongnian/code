    public class PortAdapter : UserControl
    {
        public event EventHandler<string> ValueChanged;
        protected virtual void OnValueChanged(string e)
        {
            var handler = ValueChanged;
            if (handler != null)
            {
                RunInUiThread(() => handler(this, e));
            }
        }
        private void RunInUiThread(Action action)
        {
            if (InvokeRequired)
            {
                Invoke(action);
            }
            else
            {
                action.Invoke();
            }
        }
    }
