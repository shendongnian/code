    var timer = new System.Threading.Timer(
        delegate
        {
            //--update functions here (large operations)
            var value = Environment.TickCount;
            //--run update using interface thread(UI Thread)
            Invoke(
                new Action(() =>
                {
                    richTextBoxOutput.Text = value.ToString();
                }));
        });
    var period = TimeSpan.FromSeconds(30);
    timer.Change(period, period);
