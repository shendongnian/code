    public class HashEntryModel { //name it whatever represents a single line in your file
      public string ElementsFile { get;set;}
      public string Hash { get;set;}
      public string ByteSize { get;set;} //sounds like an integer?  Perhaps instead of string declare as int and parse with int.TryParse?
    }
    
    public class SomeClass()
    {
     public List<HashEntryModel> HashEntries {get;set;}
    
     public SomeClass(){
       HashEntries = new List<HashEntryModel>();
     }
    
     public void SomeMethod() 
     {
      string path = Application.StartupPath + "\\checkfiles.lst";
    
      // Open the file to read from.
      foreach (string readText in File.ReadLines(path))
      {
        var elements = readText.Split('|');
        HashEntryModel current = new HashEntryModel();
        current.ElementsFile = elements[0];
        current.Hash = elements[1];
        current.ByteSize = elements[2];
        
        HashEntries.Add(current);//add the entry we just parsed to the list
      }
    
      //now anywhere in this class we can loop through the entries:
      
      foreach(HashEntryModel item in HashEntries)
      {
        Console.WriteLine(item.ElementsFile + item.Hash + item.ByteSize);
      }
    
     }
    
    }
