    StringBuilder sb = new StringBuilder();
    sb.Append("commit "+ Encoding.UTF8.GetByteCount(commitBody));
    sb.Append("\0");
    sb.Append(commitBody);
    
    var sss = SHA1.Create();
    var bytez = Encoding.UTF8.GetBytes(sb.ToString());
    var myssh = GetString(sss.ComputeHash(bytez));
    Console.WriteLine(myssh);
