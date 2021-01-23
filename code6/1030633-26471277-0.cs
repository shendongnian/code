    private void button4_Click(object sender, EventArgs e)
    {
        if(image_print() == "")
        {
           return;
           //You can write a message here to tell the user something if you want.
        }
        string s = image_print() + Print_image();
        PrintFactory.sendTextToLPT1(s); / sending to serial port
    }
