    public class contactVM
    {
    public contactVM()
    {
     contacts = new List<individualContactVM>()
    
    }
    public List<individualContactVM> contacts {get;set;}
    
    
    
    }
    
    public class individualContactVM
    {
    
    public string Name {get;set;}
    public string Phone {get;set;}
    
    }
    
