    public void SaveDataToFile(string[] array)
    {
        using (StreamWriter writer = new StreamWriter("C:\temp\file.txt", true))
        {
            writer.WriteLine(array.Join(",", array); //save it as a comma separated list
        }
    }
