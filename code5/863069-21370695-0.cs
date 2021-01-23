            var builderM1 = new StringBuilder();
            builderM1.Append((char)0x64);
            builderM1.Append((char)0x00);
            builderM1.Append((char)myip_e.Length);
            builderM1.Append((char)0x00);
            builderM1.Append(myip_e);
            builderM1.Append((char)mymac_e.Length);
            builderM1.Append((char)0x00);
            builderM1.Append(mymac_e);
            builderM1.Append((char)remotename.ToBase64().Length);
            builderM1.Append((char)0x00);
            builderM1.Append(remotename.ToBase64());
            var m1 = builderM1.ToString();
            var builderP1 = new StringBuilder();
            builderP1.Append((char)(0x00));
            builderP1.Append((char)appstring.Length);
            builderP1.Append((char)(0x00));
            builderP1.Append(appstring);
            builderP1.Append((char)m1.Length);
            builderP1.Append((char)(0x00));
            builderP1.Append(m1);
            Console.WriteLine(builderP1.ToString());
    public static string ToBase64(this string source)
    {
        return Convert.ToBase64String(Encoding.ASCII.GetBytes(source));
    }
