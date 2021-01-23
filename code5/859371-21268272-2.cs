    string currentLine = reader.ReadLine();
    if (!string.IsNullOrEmpty(currentLine))
    {
       //Logic to increment the number is written
       //Now saving the change to the file...
        string contents = ... get/create contents string from somewhere ...
        //contents is the file content with the changed numbers
        byte[] byteArray = Encoding.UTF8.GetBytes(contents);
        MemoryStream myStream = new MemoryStream(byteArray);
        File.AppendAllText("New.txt", contents); //Here is the issue
    }
