    public class RequiresAuthAttribute : Attribute { }
    public partial class MyService { 
        [RequiresAuth]
        WebGet(UriTemplate = "...")]
        public Tresult MyServiceOperation(...){ ... }
