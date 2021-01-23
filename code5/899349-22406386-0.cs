    private string RemoveBetween(String editScript, String begin, String end)
    {
       return Regex.Replace(editScript,
                            String.Format("{0}.*?{1}", begin, end),
                            String.Empty,
                            RegexOptions.Singleline)
    }
