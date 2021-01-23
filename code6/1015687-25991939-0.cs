    public class D {
        public string e {get;set;}
    }
    
    public class A {
        public string b {get;set;}
        public string c {get;set;}
        public D d {get;set;}
    }   
      
    [HttpPost]
    public void ValidateAndCreatePartner(A data)
    {
        // no need to deserialize data
        RedirectIfSuccess();
    }
