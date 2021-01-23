    for (int inputIndex = 0, outputIndex = 0; ; ++inputIndex)
    {
        var source = Controls[String.Format("txtInput{0}", inputIndex)];
        if (source == null)
            break; // No more sources
        string value = ((TextBox)source).Text;
        if (String.IsNullOrWhiteSpace(value))
            continue;
    
        var target = (TextBox)Controls[String.Format("txtOutput{0}", outputIndex++)];
        if (target == null)
            break; // No more targets
        target.Text = value;
    }
