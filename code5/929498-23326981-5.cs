    for (int inputIndex, outputIndex; inputIndex < numberOfInputs; ++inputIndex)
    {
        string value = Controls[String.Format("txtInput{0}", inputIndex)];
        if (String.IsNullOrWhiteSpace(value))
            continue;
    
        var target = (TextBox)Controls[String.Format("txtOutput{0}", outputIndex)];
        target.Text = value;
    }
