    public class MyEntity
    {
       public int Id {get;set;}
       // ... some other properties
       public string Code {get;set;}
       // if you need some other control to be visible based on 
       // whether Code is a number or not, use this to bind to Visible property. 
       // Note, this is not required in case of HyperLink
       public bool IsVisible
       {
         { get {return IsNumber(Code); }
       }
       public string NavigateUrl
       { 
          get { return GetUrl(Code); }
       }
       private bool IsNumber(string code) { // your method body here }
       private string GetUrl(string code)
       {
           if(!IsNumber(code))
           {
              return string.Format("~/PDF/{0}pdf", code);
           }
           
           return string.Format("http://www.address.com/{0}",code);
       }
    }
