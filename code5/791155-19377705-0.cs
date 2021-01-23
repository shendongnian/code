    public class MyJsonModel
    {
       public string DateTimeString { get;set; }
    }
    
    var model = new MyJsonModel();
    model.DateTimeString = DateTime.Now.ToString("MM-dd-yyyy"); //Any format you like
