    StringBuilder newTextFile = new StringBuilder();
    string[] lines = File.ReadAllLines(@"1.txt");
    foreach (string l in lines)
    {
       // logic to replace last number, saved in string newLine
       // you can find the last        
       newTextFile.Append(newLine + "\r\n");
    }
    File.WriteAllText(@"1.txt", newTextFile.ToString());
