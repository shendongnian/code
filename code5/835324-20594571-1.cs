    Application.Current.Dispatcher.Invoke(new Action(() =>
    {
        Output.Message_Box msg = new Output.Message_Box();
        msg.seeQuestion(Text, title);
        msg.Topmost = true;
        msg.Owner = Application.Current.MainWindow;
        msg.ShowDialog(); 
    
        return msg.result;               
    }));
