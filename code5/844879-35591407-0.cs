    @using System.Linq;
    @{
        var empties = Request.Url.Query
            .Split('&')
            .Where(s => !s.Contains("=") || s.Last() == '=');
        var keyExistsAndIsEmpty = empties.Any(x => x.Contains("target-key")
    }
         
