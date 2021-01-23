    new System.Threading.Thread(() => 
    { 
        string result = YourMethodName(); 
        this.Dispatcher.Invoke((Action)(() => { yourTextBox.Text = result; }));
    }).Start();
    
