    private Func<DateTime, string> formatting = dt => dt.ToShortDateString();
    private Func<DateTime, string> formattingLogic = null;
    public Func<DateTime, string> FormattingLogic
    {
        get
        {
            if (formattingLogic == null)
            {
                // some results from reflection
                string word = "Hello";
                string quote = "'";
                
                formattingLogic = dt =>
                {
                    StringBuilder str = new StringBuilder(quote);
                    str.Append(formatting(dt));
                
                    if (!string.IsNullOrWhiteSpace(word))
                        str.Append(" ").Append(word);
                
                    str.Append(quote);
                    return str.ToString();
                };
            }
            
            return formattingLogic;
        }
    }
    void Main()
    {
        Console.WriteLine(FormattingLogic(new DateTime(2013, 02, 01))); // '01.02.2013 Hello'
        Console.WriteLine(FormattingLogic(new DateTime(2013, 11, 26))); // '26.11.2013 Hello'
    }
