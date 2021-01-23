    btn1.Click += MainEvent;
    btn2.Click += MainEvent;
    btn3.Click += MainEvent;
    protected void MainEvent(object sender, EventArgs e)
    {
        string example;
        if(sender == btn1)
        {
            example = a
        }
        else if(sender == btn2)
        {
            example = b
        }
        else if(sender == btn3)
        {
            example = c
        }
    
        //Do whatever with example
    }
