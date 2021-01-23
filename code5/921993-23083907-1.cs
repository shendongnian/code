        private void server_outputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Dispatcher.CurrentDispatcher.Invoke(DispatcherPriority.Normal, () =>
                    {
                         addConsoleMessage(e.Data.ToString(), true);
                    });
        }
