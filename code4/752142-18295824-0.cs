    const string directory = @"C:\\wherever";
    string[] fiNames = new string[]{ "abc", "pas", "etc",};
    char[] alphabet =       "abcdefghijklmnopqrstuvwxyz".ToCharArray();
    int x = 0;
     string ending = "";
    for(int i = fiNames.Count()-1; i>=0; i--)
    {
      if(x%26==0)
       {
          x=0 
           if( ending=="")
              ending="1";
           else
              ending=(System.Convert.ToInt32(ending)+1).ToString();
        }
      System.IO.File.Move(directory+fiNames[i], fiNames[i]+alphabet[x].ToString()+ending); 
    x++;
    }
