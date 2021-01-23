    string spath = Directory.GetCurrentDirectory() + @"\" + "zPosting_" + 0.ToString() + ".post";
    string text = string.Empty;
    using (var sr = new StreamReader(spath))
     {
         while (!sr.EndOfStream)
         {
             text += sr.ReadLine();
         }
     }
