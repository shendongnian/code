    private void Starter_Click(object sender, RoutedEventArgs e)
    {
        var linkaddress = Address.Text;
        BackgroundWorker CheckValidAddressBW = new BackgroundWorker();
        CheckValidAddressBW.DoWork += CheckValidAddressBWDoWork;
        CheckValidAddressBW.RunWorkerCompleted += CheckValidAddressBWComplete;
        CheckValidAddressBW.RunWorkerAsync(Tuple.Create<string, Window>(linkaddress, this));
    }
    static void CheckValidAddressBWDoWork(object sender, DoWorkEventArgs e)
    {
        Tuple<string, Window> args = e.Argument as Tuple<string, Window>;
        string bandaddress = args.Item1;
        bool isValid = false;
        /* STUFF INSIDE */
        e.Result = Tuple.Create<bool, Window>(isValid, args.Item2);
    }
    static void CheckValidAddressBWComplete(object sender, RunWorkerCompletedEventArgs e)
    {
        Tuple<bool, Window> args = e.Result as Tuple<bool, Window>;
        bool result = args.Item1;
        if (result == false)
        {
            CustomMessage cm = new CustomMessage { Owner = args.Item2 };
            cm.Width = 800;
            cm.Height = 600;
            cm.Show();
        }
    }
