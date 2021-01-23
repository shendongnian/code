    Application application = new Application();
    
    // Open a doc file.
    Document document = application.Documents.Open("D:\\Test.docx");
    
    String read = string.Empty;
    List<string> data = new List<string>();
    
    for (int i = 0; i < document.Paragraphs.Count; i++)
    {
    	string temp = document.Paragraphs[i + 1].Range.Text.Trim();
    	if (temp != string.Empty)
    		data.Add(temp);
    }
    
    foreach (var item in data)
    {
    	Console.WriteLine(item);
    }
    
    // Close word.
    application.Quit();
            
