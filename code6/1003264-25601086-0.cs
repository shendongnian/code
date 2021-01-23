    Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>{
                    {0, new List<int>{1,2}},
                    {1, new List<int>{3,4}}
                };
    
                var serializer = new JavaScriptSerializer();
    
                ViewBag.Message = serializer.Serialize(dict);
