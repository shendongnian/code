    if (Process.GetProcessesByName("winword").Count() > 0)
    {
        Word.Application WordInstance = (Word.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application");
    }
    foreach (Word.Document doc in WordInstance.Documents)
    {
        if (doc.Name == "demo1.docx")
        {
            doc.Close();
            breake;
        }
     }
