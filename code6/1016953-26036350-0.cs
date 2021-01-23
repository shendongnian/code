    public static class XMLHelpers
    {
     public static XMLDocument GetXML(string KEY)
     {
        string file="";
        switch(KEY)
        {
          case "AA": file=Path.Combine(file,"AA.txt");
          break;
        }
         var xmldoc=new XMLDocument();
         xmldoc.Load(file);
         return xmldoc;
     }
    }
