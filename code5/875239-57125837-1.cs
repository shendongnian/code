    public class DemoList : List<Demo>
    {
        // using XmlSerializer this properties won't be seralized:
        string AnyPropertyInDerivedFromList { get; set; }     
    }
    public class Demo
    {
        // this properties will be seralized
        string AnyPropetyInDemo { get; set; }  
    }
