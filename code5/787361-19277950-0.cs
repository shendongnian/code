    class DotNetClass : IWindowsRuntimeInterface
    {
        void AlertCaller(string message)
        {
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                MessageBox.Show(message);
            }
        }
    }
