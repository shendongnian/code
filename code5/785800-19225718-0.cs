         using System.IO;
         ....
         // Get a StreamWriter object
        StreamWriter xmlDoc = new StreamWriter(Server.MapPath("~/FileTest/Testdo.xml"), false);
       
        // Apply the WriteXml method to write an XML document
         ds.WriteXml(xmlDoc);
         xmlDoc.Close();
