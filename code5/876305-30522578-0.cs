    string page = "E:\abccom\Cat\Mouse.aspx"
    
    string name = Path.GetFileName(page );
    string nameKey = Path.GetFileNameWithoutExtension(page );
    string directory = Path.GetDirectoryName(page );
    Console.WriteLine("{0}, {1}, {2}, {3}",
    page, name, nameKey, directory);
    
