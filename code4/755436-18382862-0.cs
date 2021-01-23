    string originalUri = "http://www.example.org/etc?query=string&query2=&query3=";
    // Create the URI builder object which will give us access to the query string.
    var uri = new UriBuilder(originalUri);
    // Parse the querystring into parts
    var query = System.Web.HttpUtility.ParseQueryString(uri.Query);
    // Loop through the parts to select only the ones where the value is not null or empty	
    var resultQuery = query.AllKeys
                           .Where(k => !string.IsNullOrEmpty(query[k]))
                           .Select(k => string.Format("{0}={1}", k, query[k]));
	
    // Set the querystring part to the parsed version with blank values removed
    uri.Query = string.Join("&",resultQuery);
    // Done, uri now contains "http://www.example.org/etc?query=string"
