    string speech_text = e.Result.Text;
    string[] speech = speech_text.Split();
    
    if (speech.Contains("next") && speech.Contains("date"))
    {
        MessageBox.Show(speech_text + "\nThe date will be the 11th");
    }
    else if (speech.Contains("date"))
    {
        MessageBox.Show(speech_text + "\nThe date is the 10th");
    }
