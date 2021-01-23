    var fb = new FacebookClient("access_token");
    
    fb.PostCompleted += (o, e) => {
        if(e.Error == null) {
            var result = (IDictionary<string, object>)e.GetResultData();
            var newPostId = (string)result.id;
        }
    };
    
    var parameters = new Dictionary<string, object>();
    parameters["message"] = "My first wall post using Facebook SDK for .NET";
    fb.PostAsync("me/feed", parameters);
