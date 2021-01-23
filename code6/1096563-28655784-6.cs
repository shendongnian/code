    private void Button_Click(object sender, RoutedEventArgs e)
    {
        byte[] stringBytes = Encoding.Unicode.GetBytes(txname.Text);
        char[] stringChars = Encoding.Unicode.GetChars(stringBytes);
        StringBuilder builder = new StringBuilder();
        Array.ForEach<char>(stringChars, c => builder.AppendFormat("\\u{0:X}", (int)c));
        Debug.WriteLine(builder);
    } 
