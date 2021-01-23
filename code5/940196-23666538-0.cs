    public void SoundRoute(object sender)
    {
        if (((Button)sender).Text == string.Empty)//This is the line I'm having trouble with. I want the string of myButton to be converted to button1, button2, etc.
        {
            SoundCall subForm = new SoundCall();
            subForm.Show();
        }
    }
