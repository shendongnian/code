    private void buttonClicked(object sender, EventArgs e)
        {
    //This will get the Type first, the name and then the last character on the Name
            synthesizer.Speak(sender.GetType().Name.Substring(sender.GetType().Name.Length - 1, 1));
        }
