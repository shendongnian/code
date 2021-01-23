    string s = "blabllabnsdfsdfsd";
    StringBuilder sb = new StringBuilder();
    int position = 0;
    // add a `-` every 4 chars
    while (position < s.Length -4) // the (-4) is to avoid the last `-`
    {
        sb.Append(s.Substring(position, 4));
        sb.Append("-");
        position += 4;
    }
    sb.Append(s.Substring(position)); // Adds the last part of the string
    Console.Out.WriteLine("out" + sb.ToString());
