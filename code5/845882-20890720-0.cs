     using (StreamReader mySR = new StreamReader(strFullPath,  Encoding.GetEncoding("iso-8859-1")  )) {
         XmlDocument lgnXml = new XmlDocument();
         lgnXml.Load(mySR);//This line has no errors,  Only to test....
    
         while ((line = mySR.ReadLine()) != null)
         {
            Console.WriteLine(line);//"Debug"
         }
       }
