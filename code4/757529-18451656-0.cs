    protected void Page_Load(object sender, EventArgs e)
    {
        string textFile1 = @"C:\Test\Test1.txt";
        string textFile2 = @"C:\Test\Test2.txt";
        string[] textFile1Lines = System.IO.File.ReadAllLines(textFile1);
        string[] textFile2Lines = System.IO.File.ReadAllLines(textFile2);
        char[] delimiterChars = { '|' };
    
        if (textFile1Lines.Count != textFile2Lines.Count)
        {
            // Do something since the line counts don't match
        }
        else
        {
    
        foreach (int i = 0; i < textFile1Lines.Count; i++)
        {
            string[] words1 = textFile1Lines[i].Split(delimiterChars);
            string compareValue1 = words1[0] + words1[1];
    
            string[] words2 = textFile2Lines[i].Split(delimiterChars);
            string compareValue2 = words2[0] + words2[1];
            
            if (!string.Equals(compareValue1, compareValue2))
            {
                // Do something
                break; // Exit the loop since you found a difference
            }
        }
    }
    }
