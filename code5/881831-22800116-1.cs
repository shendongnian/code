    bool isRunning = false; // initially it's stopped
    
    public void startDrawing()
    {
    isRunning = true;
    
    while(isRunning)
    {
    //thread to get data
    //wait
    //thread to draw it
    //refer to the above "right" example
    }
    
    }
    
    // Now let's set buttons work
    private void button1_Click(object sender, EventArgs e)
    {
    if(button1.text == "START" || button1.text == "RESUME")
    {
    button1.text = "PAUSE";
    startDrawing();
    }
    else
    {
    button.text = "PAUSE";
    isRunning = false;
    }
    }
