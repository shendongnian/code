    if (Process.GetProcessesByName("winword").Count() > 0)
    {
        Word.Application wordInstance = (Word.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application");
    
        foreach (Word.Document doc in wordInstance.Documents)
        {
            if (doc.Name == "demo1.docx")
            {
                doc.Close();
                break;
            }
         }
    }
