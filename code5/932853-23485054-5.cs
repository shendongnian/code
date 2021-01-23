    // Use ASP.Net's Javascript serializer to desrialize the json response received from 
    // call to graph.facebook.com/me/friends
    var jsSerializer = new JavaScriptSerializer();
    var jsonString = "{ \"data\": [ { \"name\": \"name1\", \"id\": \"id1\" }, { \"name\": \"name2\", \"id\": \"id2\" } ] }";
            
    // Deserialize the json to type - Dictionary<string, object>
    var dict = jsSerializer.Deserialize(jsonString, typeof(Dictionary<string, object>)) as Dictionary<string, object>;
    /*Code upto here is specific to ASP.Net - At this point, be it ASP.Net or Unity, we have a dictionary that contains a key "data" which again contains a dictionaries of name value pairs*/
    // The code from below is Linq and should work on Unity as well.
    var friendIds = (dict["data"] as ArrayList)                     // Convert the "data" key of the dictionary into its underlying type (which is an ArrayList in this case)
                    .Cast<Dictionary<string, object>>()             // ArrayList is not generic. Cast it to a generic enumerable where each element is of type Dictionary<string, object> 
                   .Select(s =>
                                {
                                    // Each element in the cast enumerable is of type dictionary.
                                    // Each dictionary has two keys - "id" and "name" that correspond to the id and name properties 
                                    // of the json response received when calling graph.facebook.com/me/friends.
                                    // check - https://developers.facebook.com/tools/explorer/145634995501895/?method=GET&path=me%2Ffriends&version=v2.0
                                    // Because we only want Ids, fetch the value corresponding to the "id" key
                                    object id = null;
                                    if (s.TryGetValue("id", out id))
                                    {
                                        return id.ToString();
                                    }
                                    return string.Empty;
                                });
