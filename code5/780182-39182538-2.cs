    public void PrintStars(string s)
    {
        if (int.TryParse(s, out var i)) { WriteLine(new string('*', i)); }
        else { WriteLine("Cloudy - no stars tonight!"); }
    }
