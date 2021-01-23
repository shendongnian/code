    private void SpeechHypothesized(object sender, SpeechHypothesizedEventArgs e)
    {
        string speech = e.Result.Text;
        bool matchesDate = Regex.IsMatch(speech, @"\bdate\b");
        if (Regex.IsMatch(speech, @"\bnext\b") && matchesDate)
        {
            MessageBox.Show(speech + "\nThe date will be the 11th");
        }
        else if (matchesDate)
        {
            MessageBox.Show(speech + "\nThe date is the 10th");
        }
    }
