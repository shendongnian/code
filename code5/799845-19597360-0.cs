    using (TextWriter writer = File.CreateText("C:\\perl.txt"))
    {
       StringBuilder sb = new StringBuilder();
       for (int i = 1; i <=10 ; i++)
       {
         sb.AppendLine(string.Format("{0} {1} {2},nombres[i],temp[i],cap[i]);
       }
      writer.Write(sb.ToString());
    }
