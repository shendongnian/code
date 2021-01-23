    public class MyCustomClass //this class will hold your data
    {
        public string Left {get; set;}
        public string Right {get;set;}
    }
    
    MyCustomClass mcc=new MyCustomClass(); //create an instance of your class
    mcc.Left="yes"; //set some properties
    mcc.Right="nope";
    string json=JsonConvert.SerializeObject(mcc); //convert to JSON string
    File.WriteAllText("mcc.txt",json); //save to file
    
    //later on, when you want to read it back from the file
    string json=File.ReadAllText("mcc.text"); //read from file into a string
    MyCustomClass mcc=JsonConvert.DeserializeObject<MyCustomClass>(json); //convert the string back to an instance of MyCustomClass
