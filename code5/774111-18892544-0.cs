    var fs = new System.IO.FileStream(@"D:\log.txt", System.IO.FileMode.Append);
    var tr = new System.IO.StreamWriter(fs);
    Console.SetOut(tr);
    Console.WriteLine("My Default Debugging");
    tr.Close();
    fs.Close();
