    public string CleanText()
    {
        if (this.Text == null) { return null; }
        else {
            return (Regex.Replace(this.Text, "<p>&nbsp;</p>$", ""));
        }
    } 
