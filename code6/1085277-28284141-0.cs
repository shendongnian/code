    void Main()
    {
       String aciResponseData = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><tag><bar>test</bar></tag>";
       using(TextReader sr = new StringReader(aciResponseData))
       {
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(MyClass));
            MyClass response =  (MyClass)serializer.Deserialize(sr);
    		Console.WriteLine(response.bar);
       }
    }
    
    [System.Xml.Serialization.XmlRoot("tag")]
    public class MyClass
    {
       public String bar;
    }
