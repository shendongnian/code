    var timer = new System.Threading.Timer(
        delegate
        {
            //--update functions here (large operations)
            var value = Environment.TickCount;
            //--run update using interface thread(UI Thread)
            
            //--for WinForms
            Invoke(
                new Action(() =>
                {
                    //--set the value to UI Element
                }));
            //--for WPF
            Dispatcher.Invoke(
                new Action(() =>
                {
                    //--set the value to UI Element
                }), null);
        });
    var period = TimeSpan.FromSeconds(30);
    timer.Change(period, period);
