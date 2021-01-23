    var bw1 = new BackgroundWorker();
    var bw2 = new BackgroundWorker();
    var bw3 = new BackgroundWorker();
    bw1.DoWork += (sender, args) => args.Result = Operation1();
    bw2.DoWork += (sender, args) => args.Result = Operation2();
    bw3.DoWork += (sender, args) => args.Result = Operation2();
    bw1.RunWorkerCompleted += (sender, args) => {
        if ((bool)args.Result)
        {
            richTextBox.AppendText("Operation1 ended\n");
            bw2.RunWorkerAsync();
        }
    };
    bw2.RunWorkerCompleted += (sender, args) => {
        if ((bool)args.Result)
        {
            richTextBox.AppendText("Operation2 ended\n");
            bw3.RunWorkerAsync();
        }
    };
    bw3.RunWorkerCompleted += (sender, args) => {
        if ((bool)args.Result)
        {
            richTextBox.AppendText("Operation3 ended\n");
        }
    };
    bw1.RunWorkerAsync();
