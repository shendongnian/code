    void CopyContentOfFile(string file1, string file2)
    {
        byte[] val = File.ReadAllBytes(file1);
        File.WriteAllBytes(file2, val);
    }
    CopyContentOfFile("test1.txt","test2.txt"); //copy test1 to test2.
