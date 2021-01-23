    byte[] fileContent = File.ReadAllBytes(openFileDialog.FileName);
    byte[] endCharacter = new byte[] { fileContent[fileContent.Count() - 2], fileContent[fileContent.Count() - 1] };
    
    if (!(endCharacter.SequenceEqual(Encoding.ASCII.GetBytes(Environment.NewLine))))
    {
         fileContent.Concat(Encoding.ASCII.GetBytes(Environment.NewLine));
         File.AppendAllText(openFileDialog.FileName, Environment.NewLine);
    } 
