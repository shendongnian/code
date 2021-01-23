    public List<string> connect(String query_physician, String query_institution)
    { ...
        
        //restults container
        List<string> resultContainer = new List<String>(); 
   
        Regex pattern = new Regex(@"(?<=""link""\:\s"")[^""]*(?="")");
        MatchCollection linkMatches = pattern.Matches(customSearchResult);
        var list = new List<string>();
        list = linkMatches.Cast<Match>().Select(match => match.Value).ToList(); //put the links into a list?!
        foreach (var item in list) //take each item (link) out of the list...
        {
            //add item to list
            resultContainer.Add(item); 
        }
        return resultContainer;
}
