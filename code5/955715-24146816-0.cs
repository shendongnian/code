    List<string> strList = new List<string>();
    List<float> fltList = new List<float>();
     StringBuilder sb = new StringBuilder();
     for(int i = 0; i < richTextBox.Text.Length; i++)
     {
      if(!char.IsDigit(richTextBox.Text[i]) && richTextBox.Text[i] != "-")
           {
            if(sb.ToString().Length > 0)
                strList.Add(sb.ToString());
            sb.Clear();
           }
       else
           sb.Add(richTextBox.Text[i]);
       }
      float numOut;
      foreach(string num in strList)
      {
        if( float.TryParse(num, out numOut) )
            fltList.Add(numOut);
      }
