    public class MyXmlRoot{
    
    private string[] allowedTags={"tagA","tagB","tagC"};
    [XmlAnyElement]
    public List<XmlElement> children = new List<XmlElement>(); //populated after serialization
    
    public string GetValueByKey(string key){
      return children.Find(k => k.Name == key).InnerText;
    }
    public void UseTags(){
        for(int i=0;i<allowedTags.Length;i++){
            Console.WriteLine(allowedTags[i]+" = "+GetValueByKey(allowedTags[i]));
        }
    }
    
    }
