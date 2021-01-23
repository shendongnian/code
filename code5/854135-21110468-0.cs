    var textToWriteBuilder = new StringBuilder();
    
    for (int i = 0; i < m.rows; i++)
    {
        for (int j = 0; j < m.cols; j++)
        {
            textToWriteBuilder.Append(m[i, j].ToString() + ",");
        }
    	
        // I've modified the logic on the following line, I assume you want to 
        // concatenate the value instead of overwriting it as you do in your question.
        textToWriteBuilder.Append(textToWriteBuilder.Substring(0, textToWriteBuilder.Length - 2));
        textToWriteBuilder.Append(Environment.NewLine);
    }
    
    string textToWrite = textToWriteBuilder.ToString();
