    // Imagining you got your blob of data, spaces and all, in one hit.  
    string blob = myWayOfGettingData;
    textBox1.Text = blob;
    int lineIndex = 0;
    string[] allLines = new string[textBox1.Lines.Count()];
    allLines = textBox1.Lines;
    foreach (string line in textBox1.Lines)
    {
        if (!string.IsNullOrEmpty(line))
        {
             allLines[lineIndex] = "$" + allLines[lineIndex];       
         }
         lineIndex++;
     }
     textBox1.Lines = allLines;
