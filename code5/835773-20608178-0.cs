    private IEnumerable<char> AllChars()
    {
        // using the same loop header as the example here:
        for (int ctr = Convert.ToInt32(char.MinValue); ctr <= Convert.ToInt32(char.MaxValue); ctr++) {
            yield return (char)ctr;
        }
    }
