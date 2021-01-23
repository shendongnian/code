    private void button1_click(object sender, EventArgs e)
    {
        //Do first stuffs
        button2_click(sender, e);
        
        //Reading the tag value of sender object that is assigned in that case
        if (!(bool)(sender as Button).Tag)
            return;
        //Do second stuffs
    }
    private void button2_click(object sender, EventArgs e)
    {
        //Do something
        //Since sender object is button1 in the example
        Button button = sender as Button;
        button.Tag = true;
        if (myCondition)
        {
            button.Tag = false;
            return;
        }//Also return in button1_click
        //Do somthing else
    }
