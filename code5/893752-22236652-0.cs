    using System;
    using System.Collections.Generic;
    using System.Web.Script.Serialization;
    namespace ConsoleApplication1 {
       class Program {
          [Serializable]
          public class ContactsListResult {
             public string Contact { get; set; }
             public int ContactID { get; set; }
          } //
          [Serializable]
          public class CList {
             public List<ContactsListResult> ContactsListResult = new   List<ContactsListResult>();
          } //
          static void Main(string[] args) {
             string s = "{\"ContactsListResult\":[{\"Contact\":\"Fred Smith\",\"ContactID\":25},{\"Contact\":\"Bill Wilson\",\"ContactID\":45}]}";
             JavaScriptSerializer lSerializer = new JavaScriptSerializer();
             CList lItems = lSerializer.Deserialize<CList>(s);
             foreach (ContactsListResult lItem in lItems.ContactsListResult) Console.WriteLine(lItem.Contact + " " + lItem.ContactID);
             Console.ReadLine();
          } //
       } // class
    } // namespace
