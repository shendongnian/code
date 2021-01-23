    string data = "1Position1234Article4321Quantity2Position4323Article3323Quantity";
    StringBuilder sb = new StringBuilder();
    StringBuilder sbWord = new StringBuilder();
    bool isDigit = false;
    bool isChar = false;
    Dictionary<int, string> dic = new Dictionary<int, string>();
    int index = 0;
    for (int i = 0; i < data.Length; i++)
     {
      if (char.IsNumber(data[i]))
       {
         isDigit = true;
         if (isChar)
          {
             dic.Add(index, sb.ToString() + "|" + sbWord.ToString());
             index++;
             isChar = false;
             sb.Remove(0, sb.Length);
             sbWord.Remove(0, sbWord.Length);
          }
         }
         else
                {
                    isDigit = false;
                    isChar = true;
                    sbWord.Append(data[i]);
                }
                if (isDigit)
                    sb.Append(data[i]);
                if (i == data.Length - 1)
                {
                    dic.Add(index, sb.ToString() + "|" + sbWord.ToString());
                }
            }
            List<string> Position = new List<string>();
            List<string> Article = new List<string>();
            List<string> Quantity = new List<string>();
            if (dic.Count > 0)
            {
                for (int i = 0; i < dic.Count; i++)
                {
                    if (dic[i].Split('|')[1] == "Position")
                        Position.Add(dic[i].Split('|')[0]);
                    else if (dic[i].Split('|')[1] == "Article")
                        Article.Add(dic[i].Split('|')[0]);
                    else
                        Quantity.Add(dic[i].Split('|')[0]);
                }
            }
            string[] Position_array = Position.ToArray();
            string[] Article_array = Article.ToArray();
            string[] Quantity_array = Quantity.ToArray();
