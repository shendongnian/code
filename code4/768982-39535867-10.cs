    /* To help illustrate */
    public static List<Person> list = new List<Person>();
    
    /* To help illustrate */
    public class Person
    {
      public string name;
      public string address;
      public string phoneNumber;
    }
    /* The important part */
    public FileContentResults DownloadCSV()
    {
      StringBuilder sbRtn = new StringBuilder();
      // If you want headers for your file
      var header = string.Format("\"{0}\",\"{1}\",\"{2}\"",
                                 "Name",
                                 "Address",
                                 "Phone Number"
                                );
      sbRtn.AppendLine(header);
      foreach (var item in list)
      {
          var listResults = string.Format("\"{0}\",\"{1}\",\"{2}\"",
                                            item.name,
                                            item.address,
                                            item.phoneNumber
                                           );
          sbRtn.AppendLine(listResults);
        }
      }
      
      return File(new System.Text.UTF8Encoding().GetBytes(sbRtn.ToString()), "text/csv", "FileName.csv");
    }
