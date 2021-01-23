    for (int inputIndex = 0, outputIndex = 0; inputIndex < numberOfInputs; ++inputIndex)
    {
        string value = ((TextBox)Controls[String.Format("txtInput{0}", inputIndex)]).Text;
        if (String.IsNullOrWhiteSpace(value))
            continue;
    
        var target = (TextBox)Controls[String.Format("txtOutput{0}", outputIndex++)];
        if (target == null)
            break; // No more targets
        target.Text = value;
    }
