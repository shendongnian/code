    string word = input_box.Text;
    string[] split = word.Split(new char[] { ',', ' ' });
    StringBuilder sb = new StringBuilder();
    foreach (string s in split)
    {
         if (s.Trim() != " ")
             sb.Append(s);
    }
    
    label1.Content = sb.ToString();
