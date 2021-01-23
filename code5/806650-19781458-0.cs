    class SomeClass {
     public string MyObject { get; set; }
     public string MyValue { get; set; }
     public string MyAttribute { get; set; }
    }
    
    private List<SomeClass> myList = new List<SomeClass>();
    
    public void ReadCsv(){
     using (var sr = new StreamReader("PathToCsvFile")) {
      string currentLine;
    
      while ((currentLine = sr.ReadLine()) != null) {
       var elements = currentLine.Split(',');
       myList.add(new SomeClass {
        MyObject = elements[0],
        MyValue = elements[1],
        MyAttribute = elements[2]
       });
      }
     }
    }
