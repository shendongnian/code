    public static List<String> GetItemByQuery(IAmazonSimpleDB simpleDBClient, string domainName)
        {
           List<String> Results = null;
            SelectResponse response = simpleDBClient.Select(new SelectRequest()
            {
                SelectExpression = "Select * from " + domainName
            });
            String res = domainName + " has: ";
    
            foreach (Item item in response.Items)
            {
                Results = new List<String>();
                res = item.Name + ": ";
                foreach (Amazon.SimpleDB.Model.Attribute attribute in item.Attributes)
                {
                    res += "{" + attribute.Name + ", " + attribute.Value + "}, ";
                }
                res = res.Remove(res.Length - 2);
                Results.Add(res);
            }
    
            return Results;
        }
