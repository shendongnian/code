    private void SpeechHypothesized(object sender, SpeechHypothesizedEventArgs e)
    {
        string speech = e.Result.Text;
    
        if (Regex.IsMatch(speech, @"\bnext\b") && Regex.IsMatch(speech, @"\bdate\b"))
        {
            MessageBox.Show(speech + "\nThe date will be the 11th");
        }
        else if (Regex.IsMatch(speech, @"\bdate\b"))
        {
            MessageBox.Show(speech + "\nThe date is the 10th");
        }
    }
