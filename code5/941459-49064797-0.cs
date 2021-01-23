    public class MinfyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            var response = filterContext.HttpContext.Response;
            if (!filterContext.IsChildAction) //<--you need to make sure context is not a child action
            {
                response.Filter = new Minify(response.Filter, s =>
                {
                    s = Regex.Replace(s, @"\s+", " ");
                    s = Regex.Replace(s, @"\s*\n\s*", "\n");
                    s = Regex.Replace(s, @"\s*\>\s*\<\s*", "><");
                    s = Regex.Replace(s, @"<!--(.*?)-->", "");   //Remove comments
                    var firstEndBracketPosition = s.IndexOf(">");
                    if (firstEndBracketPosition >= 0)
                    {
                        s = s.Remove(firstEndBracketPosition, 1);
                        s = s.Insert(firstEndBracketPosition, ">");
                    }
                    return s;
                }); // i'm getting exception here on this code block
            }
        }
    }
