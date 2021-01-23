    class QueryPropertyMessage
    {
        public Action<QueryPropertyMessage> Callback { get; private set; }
        public string PropertyName { get; set; }
        public object PropertyValue { get; set; }
    
        public QueryPropertyMessage(Action<QueryPropertyMessage> callback)
        {
            this.Callback = callback;
        }
    
    }
    
    public class TestClass
    {
        public void OuterTestFunction()
        {
            
            //the function will set PeropertyValue
            SomeClass.FunctionAcceptingQueryPropertyMessageObject (new QueryPropertyMessage ((item) =>
            {
                Helper.DebugHelper.TraceMessage ("Test Anonymous method");
                //Error The name 'PropertyValue' does not exist in the current context
                If(item.PropertyValue!=null)
                    var val = Convert.ChangeType (PeropertyValue, typeof (bool));
            }) { PropertyName = "SomeBooleanProperty" });
        }
    }
    }
