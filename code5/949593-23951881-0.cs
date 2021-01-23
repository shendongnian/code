    public void CreateNewFolder()
    {
        List<String> lines = File.ReadAllLines(stringFile, Encoding.UTF8).ToList();
        lines.Add("Test");
        File.WriteAllLines(stringFile, lines.ToArray(), Encoding.UTF8);
        //Calling the ToArray method for lines is not necessary 
    } 
