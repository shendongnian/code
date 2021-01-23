    [DllImport("Advapi32", SetLastError = false)]
    static extern bool IsTextUnicode(byte[] buf, int len, ref int opt);
    ...
    int iter = 20;
    string test = string test = String.Join("", Enumerable.Repeat("0,1,0,1,0,1,0,1,", iter));
    var bytes = UTF8Encoding.UTF8.GetBytes(test);
    int opt = 0x20; // IS_TEXT_UNICODE_STATISTICS;
    Console.WriteLine(IsTextUnicode(bytes, bytes.Length, ref opt));
