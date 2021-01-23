      string sRecontent = txtrepalcecontent.Text;
      string[] fileLineString = new string[sContent.Length];
      for (int i =0 ; i < sContent.Length; i++)
 
      {
          //fileLineString[0] = sContent[0].ToString();
          string[] content = sContent.Split(delim);
          if (sFind == content[i])  **//index was outside the bounds the array**
          {
              string A = sContent.Remove(i, txtfind.Text.Length);
              string S = A.Insert(i, sReplace);
              txtrepalcecontent.Text = S;
          }
  
