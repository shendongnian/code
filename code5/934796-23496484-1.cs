        void DataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                textBox1.Dispatcher.BeginInvoke(new SetText(UpdateText), DispatcherPriority.Normal, e.Data);            }
        }
