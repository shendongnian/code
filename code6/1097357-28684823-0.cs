    public class Row
    {    
         public Row(string content)
         {
              var item = content.Split('-', StringSplitOptions.None);
              Example = item[0];
              Demonstration = item[1];
              Format = item[2];
         }
         public string Example { get; set; }
         public string Demonstration { get; set; }
         public string Format { get; set; }
    } 
