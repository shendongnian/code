    string source = @"d:\test.docx";
    string target = @"d:\test.txt";
    // load the docx
    using (DocX document = DocX.Load(source))
    {
        string text = document.Text;
        // optionally, write as a text file
        using (StreamWriter writer = new StreamWriter(target)) 
        {
           writer.Write(text);           
        }
        Console.WriteLine(text); 
        Console.Read();
    }
