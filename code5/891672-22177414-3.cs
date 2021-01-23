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
