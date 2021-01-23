        importFile = File.ReadAllText(fileName).Split('\n');
        StringBuilder newContents = new StringBuilder();
    
        foreach (string line in importFile)
        {
            data = line.Split(',');
            userName = data[0]; // "Ben"
            password = data[1]; // "welcome1"
    
            if (data[0] == UModel.UserName && UModel.UserPassword == data[1])
            {
                line = data[0] + "," + UModel.ConfirmPassword + "," + data[2];
                newContents.Append(line);
                newContents.AppendLine();
            }
        }
    
        File.WriteAllText(fileName, newContents.ToString());
