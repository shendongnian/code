    public class Task() {
       public Task() { }
       //need a default constructor with no parameters for model binding to work 
    
       public string Objects { get; set; }
       //property name "Objects" matches value of input/select/textarea's name attribute
    
       public string ObjectType { get; set; }
    
       //other methods / properties as needed...
    }
