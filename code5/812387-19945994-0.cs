    void baseMenuItem_Click(object sender, RoutedEventArgs e)
    {
        Control senderAsControl = (Control)sender;
        Type windowType = Type.GetType((string)(senderAsControl.Tag));
        Control window = (Control)Activator.CreateInstance(windowType);
        window.Show();
    }
