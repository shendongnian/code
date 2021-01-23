    string fileName = @"C:\Users\Test\Downloads\hello.sql";
    byte[] buffer = File.ReadAllBytes(fileName);
    Encoding enc = Encoding.GetEncoding(1252);
    char[] chars = enc.GetChars(buffer);
    for (int n = 0; n < chars.Length; n++)
    {
        if (char.IsControl(chars[n])) chars[n] = '.';
    }
    textBox1.Text = new string(chars);
