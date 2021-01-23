    The best overloaded method match for 'System.Collections.Generic.ICollection.Add(System.Web.WebPages.Html.SelectListItem)' 
    has some invalid arguments
    
    The best overloaded method match for 'System.Collections.Generic.ICollection.Add(System.Web.WebPages.Html.SelectListItem)' has some invalid arguments
    The two above errors there is somekind of miss-match between references, you controller has the `using System.Web.Mvc` the view is somehow picking up `System.Web.WebPages.Html`, check that there is no `@using System.Web.WebPages.Html` in the view.
    
    'System.Collections.Generic.IList' does not contain a definition for 'AddRange' and no extension method 'AddRange' accepting a first argument of type 'System.Collections.Generic.IList' could be found (are you missing a using directive or an assembly reference?)
