    [HttpPost]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public ActionResult Search(User userinfo) 
    {
        const string noResult = "Search Result Not Found";
        var itemforSearch = new List<User>();
        using (var uc = new UserContext()) 
        {
            if (userinfo.Name == null && userinfo.Email == null)
            {
                List<User> users;
                users = uc.UserList.ToList();
                return new JsonResult { Data = null };
            }
            if (userinfo.Name != null) 
            {
                itemforSearch = uc.UserList.Where(o => o.Name == userinfo.Name).ToList();
                return GetSearchedItem(noResult, itemforSearch);
            } 
            else 
            {
                if (userinfo.Email != null) 
                {
                    itemforSearch = uc.UserList.Where(o => o.Email == userinfo.Email).ToList();
                    return GetSearchedItem(noResult, itemforSearch);
                }
            }
        }
        return View(itemforSearch);
    }
    
    private ActionResult GetSearchedItem(string noResult, List<Models.User> itemforSearch) 
    {
        if (itemforSearch.Count > 0) 
        {
            // Not sure how JsonResult works with lists but try take a look at this post http://stackoverflow.com/questions/9110724/serializing-a-list-to-json
            return new JsonResult { Data = itemforSearch };
        } 
        else 
        {
            throw new Exception("User with provided information was not find");
        }
    }
