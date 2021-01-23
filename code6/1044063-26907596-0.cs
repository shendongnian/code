    var a = 10;
    var b = 10;
    var c = a * b;
    
    System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\test.txt");
    file.WriteLine(c);
    
    file.Close();
