    button1.Tag = "1";
    button2.Tag = "2"; 
    ...
    private void button_Click(object sender, EventArgs e)
    {
        synthesizer.Speak(((Button)sender).Tag.ToString());
    }
