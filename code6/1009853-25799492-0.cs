    void initTest()
    {
        TextBox tx = new TextBox();
        tx.SpellCheck.IsEnabled = true;
        tx.Text = "saf and tre";
        var split = tx.Text.Split(' ');
        var errors = 0;
        foreach (var s in split)
        {
            var tempTb = new TextBox();
            tempTb.SpellCheck.IsEnabled = true;  // Added this line
            tempTb.Text = s;
            SpellingError e = tempTb.GetSpellingError(0); // no longer always null
            var a = tempTb.GetSpellingErrorLength(0);
            var b = tempTb.GetSpellingError(0);
            var c = tempTb.GetSpellingErrorStart(0);
            //if (tempTb.GetSpellingErrorLength(0) >= 0)  //doesn't appear to be correct 
            if (e != null)
            {
                errors++;
            }
        }
    }
