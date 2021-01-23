    private string lastMessage = "";
    private string tempFilePath = System.IO.Path.GetTempPath() + "MyApp.txt";
    
    private void button1_Click(object sender, EventArgs e)
    {
        File.WriteAllText(tempFilePath, lastMessage);
    
        var notepadProcess = new Process();
        notepadProcess.StartInfo.FileName = "notepad.exe";
        notepadProcess.StartInfo.Arguments = tempFilePath;
        notepadProcess.Start();
        notepadProcess.WaitForExit();
    
        lastMessage = File.ReadAllText(tempFilePath);
        File.Delete(tempFilePath);
    }
