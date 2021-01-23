    private void btnSplit_Click(object sender, EventArgs e)
    {
        List<string> words=new List<string>();
        string[] splittedWords = rich.Text.Split(' ');
        int counter = 0;
        string tempWordHolder="";
        foreach (string word in splittedWords)
        {
            tempWordHolder += " " + word;
            counter++;
            if (counter > 500) continue;
            counter = 0;
            words.Add(tempWordHolder);
            tempWordHolder = "";
        }
    
        if (!string.IsNullOrEmpty(tempWordHolder))
            words.Add(tempWordHolder);
    }
