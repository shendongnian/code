    var lines1 = textBox1.Texts.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
    var lines2 = textBox2.Texts.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
    string result = String.Empty;
    if (lines1.Length == lines2.Length)
    {
       for(int i=0; i< lines1.Length; ++i)
       {
           result += lines1[i] + ":" + lines2[i] + Environment.NewLine;
       }
    }
