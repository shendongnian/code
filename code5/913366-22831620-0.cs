    string str = "+ - && || ! ( ) { } [ ] ^ \" ~ * ? : \\";
    string[] array = str.Split();
    string s = "123 ~Main";
    StringBuilder sb = new StringBuilder();
    foreach (var c in s)
    {
        sb = array.Contains(c.ToString()) ? sb.Append("") : sb.Append(c);
    }
    Console.WriteLine(sb.ToString()); // 123 Main
    Console.ReadLine();
