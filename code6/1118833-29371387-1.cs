    private void Button01_click(object sender, EventArgs e)
    {
        //...
        foreach (EventHandler eh in timer2.Tick.GetInvocationList())
        {
            timer2.Tick -= eh;
        }
        timer2.Tick += (obj, args) =>
        {
            //...
        };
        //...
    }
