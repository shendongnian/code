    var fileContents = System.IO.File.ReadAllLines(textBox5.Text);
        var outFileContents = new List<string>();
        foreach (var line in fileContents)
        {
            if (line.Contains("Start **** Connect Process"))  //Text to find 
                outFileContents.Add(line + "," + Environment.NewLine + "*****" + Environment.NewLine); //Add your text
            else
                outFileContents.Add(line + ","); //Keep column
            if (line.Contains("Start $$$$$$ Connect Process"))
                outFileContents.Add(line + "," + Environment.NewLine + "$$$$$$" + Environment.NewLine);
            else
                outFileContents.Add(line + ",");
            if (line.Contains("Fail to send &&&&&&&&"))
                outFileContents.Add(line + "," + Environment.NewLine + "&&&&&&" + Environment.NewLine);
            else
                outFileContents.Add(line + ",");
            if (line.Contains("Start @@@@@ Process"))
                outFileContents.Add(line + "," + Environment.NewLine + "@@@@@@" + Environment.NewLine);
            else
                outFileContents.Add(line + ",");
            if (line.Contains("ConnectionStatus: ######"))
                outFileContents.Add(line + "," + Environment.NewLine + "######" + Environment.NewLine);
            else
                outFileContents.Add(line + ",");
        }
        System.IO.File.WriteAllLines(textBox6.Text, outFileContents);
        Process.Start(textBox6.Text);
