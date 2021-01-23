    if (method == "RegisterUser") 
    {
    				RequestProcessor rp = new RequestProcessor();
    				var parameters = System.Web.HttpUtility.ParseQueryString (resources [1]);
    				Dictionary<string,string> requestParams = new Dictionary<string,string> ();
    				string email = parameters["email"];
    				requestParams.Add ("email", email )
    				rp.HttpPostRequest("users/add", requestParams);
    				rp.HttpGetRequest("users/add?email" + email);
    }
