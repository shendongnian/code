    public class ActionLinkModel
    {
        public string LinkText { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public IDictionary<string, object> RouteValues { get; set; }
        public IDictionary<string, object> HtmlAttributes { get; set; }
    }
