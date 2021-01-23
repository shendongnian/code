    SmsSender sms = new SmsSender();
    DataView result = sms.GetAllInboxMessagesDataSet().Tables[0].DefaultView
    Action action = () =>
    {
        dgUser1.ItemsSource = result;
    };
    dgUser1.Dispatcher.BeginInvoke(action);
