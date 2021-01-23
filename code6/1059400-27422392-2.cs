     using System.Xml.Linq;
     public class SampleModel
     {
         private XDocument document;
         public int Id {get;set;}
         public string FirstName 
         {
             get { return document.Descendants("firstname").Single().Value; }
         }
           
         // other properties in the same manner
         // Dynamic
         public string GetData(string fieldName)
         { 
            return document.Descendants(fieldname).Single().Value;
         }
 
         public SampleModel(){}
         public SampleModel(int id, string xml)
         {
            this.Id = id;
            this.document = XDocument.Parse(xml);
         }
           
     }
