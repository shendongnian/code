    void Names_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        Dispatcher.CurrentDispatcher.BeginInvoke(new Action(() =>
        {
            if (e.PropertyName == "Stuff" && m_Stuff != things.a)
            {
                Stuff = things.a;
            }
        }));
    }
