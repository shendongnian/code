    class Program
      {
        static void Main(string[] args)
        {
          string xml = @"<maintag>
               <CENTER>
                  <ID>11</ID>
                  <CENTER>333</CENTER>
               </CENTER>
               <PRODUCTID>100</PRODUCTID>
               <LastNum>0900</LastNum>
        </maintag>";
    
          XmlDocument xd = new XmlDocument();
          xd.LoadXml(xml);
    
          string center = xd.DocumentElement.SelectSingleNode("CENTER/CENTER").InnerText;
          string id = xd.DocumentElement.SelectSingleNode("CENTER/ID").InnerText;
       
    
        }
