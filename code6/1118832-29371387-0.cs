    private void Button01_click(object sender, EventArgs e)
    {
        //...
        timer2.Tick = null; //this removes all event handlers
        timer2.Tick += (obj, args) =>
        {
            //...
        };
        //...
    }
