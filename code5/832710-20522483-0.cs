    void Main()
    {
        string wrong = "Ã¦ Ã¸ Ã¥";
        var bytes = Encoding.GetEncoding("iso-8859-1").GetBytes(wrong);
        string correct = Encoding.UTF8.GetString(bytes);
        correct.Dump();
    }
