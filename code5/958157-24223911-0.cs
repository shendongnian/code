    string tempFile = Path.GetTempFileName();
    string fileName = Dts.Variables["User::File_Name_Path_4"].Value.ToString();
    using (var writer = new StreamWriter(tempFile))
    using (var reader = new StreamReader(fileName))
    {
    	while(!reader.EndOfStream)
    	{
    	    writer.WriteLine(reader.ReadLine().Replace("#Fields: ", ""));
    	}
    }
    File.Delete(fileName);
    File.Move(tempFile, fileName);
