    List<String> Lines = new List<String>();
    System.IO.StreamReader file = 
       new System.IO.StreamReader("c:\\test.txt");
    while((line = file.ReadLine()) != null)
    {
       myFlowDoc.Blocks.Add(new Paragraph(new Run(x)));
       Lines.Add(line);
    }
    
    file.Close();
