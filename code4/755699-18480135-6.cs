    private void Form1_Load(object sender, EventArgs ev)
    {
        var traceView = TraceView.Create(this);
        for (var i = 0; i < 1000; i++)
        {
            var _i = i;
            Task.Run(() => 
            {
                traceView.Write(String.Format("Line: {0}\n", _i), System.Drawing.Color.Green);
            });
        }
    }
