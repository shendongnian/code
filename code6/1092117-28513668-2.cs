    while((line = DOC.ReadLine()) != null)
    {
        List<string> linestring = new List<string>();
        List<double> numbers = new List<double>();
        double val;
    
        string[] words = line.Split(' ');
        foreach (string word in words)
        {
            if(Double.TryParse(word, out val)
            {
                numbers.Add(val);
            }
            else
            {
                linestring.Add(word);
            }    
        }
    }
