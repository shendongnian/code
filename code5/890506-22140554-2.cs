    protected override void Execute(CodeActivityContext context)
    {
        // Obtain the runtime value of the Text input argument
        string TextFileName = context.GetValue(this.TextFileName);
        string TextFilePath = TextFileName;
        string number = null;
        var splitChars = new[]{ ' ' };
        foreach (var line in File.ReadLines(TextFilePath))
        {
            var values = line.Split(splitChars, StringSplitOptions.RemoveEmptyEntries).ToArray();
            if (values.Length < 3)
                continue;
 
            buildNumber = (values[1] == 'Rel' ? values[0] : buildNumber);
        }
        context.SetValue<string>(this.setBuildNumber, number);        
    }
