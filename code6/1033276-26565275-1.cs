    using System.Text;
    string Encrypt(string text)
    {
        return string.Concat(
            Encoding.Unicode.GetBytes(text).Select(b => b.ToString("x2")));
    }
