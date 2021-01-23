    public class RazorConfig : IRazorConfiguration
    {
        public IEnumerable<string> GetAssemblyNames()
        {
            yield return "MyWebsite.Web";
            yield return "MyWebsite.Models";
            yield return "Sandra.SimpleValidator";
            yield return "ServiceStack.Text";
        }
        public IEnumerable<string> GetDefaultNamespaces()
        {
            yield return "Nancy.Validation";
            yield return "System.Globalization";
            yield return "System.Collections.Generic";
            yield return "System.Linq";
            yield return "MyWebsite.Web";
            yield return "MyWebsite.Models";
            yield return "MyWebsite.Web.ViewModels";
            yield return "MyWebsite.Web.Helpers.RazorHelpers";
        }
        public bool AutoIncludeModelNamespace
        {
            get { return true; }
        }
    }
