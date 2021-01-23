    public class MyUrlHelper : UrlHelper 
    {
        public override string Action(string actionName)
        {
            return base.Action(actionName, new RouteValueDictionary());  
        }
    }
