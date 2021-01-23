    using System.Diagnostics;
    using System.IO;
    string filename = @"C:\Foo\Bar.txt";
    for (int count = 0; count < 100; count++)
    {
        char letter = (char)((int)'a' + count % 26);
        string numeric = (count / 26) == 0 ? "" : (count / 26).ToString("000");
        Debug.Print(Path.GetFileNameWithoutExtension(filename) + "_" + letter + numeric + Path.GetExtension(filename));
    }
