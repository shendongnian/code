    public class QueryPropertyMessage
    {
        public Action<QueryPropertyMessage> Callback { get; private set; }
        public string PropertyName { get; set; }
        public object PropertyValue { get; set; }
        public QueryPropertyMessage(Action<QueryPropertyMessage> callback)
        {
            this.Callback = callback;
        }
    }
---
    new QueryPropertyMessage(props =>
    {
        var propertyName = props.PropertyName;
    });
