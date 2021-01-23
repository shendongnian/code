    Dictionary<string, string> iRequestObjects = new Dictionary<string, string>();
    iRequestObjects.Add("Query String", queryString );
    iRequestObjects.Add("Item2", "ItemData");
    
    ThreadPool.QueueUserWorkItem(new WaitCallback(iLogEventSave),iRequestObjects);
    
    public void iLogEventSave(object state)
    {
        IDictionary<object, object> dObject = (IDictionary<object, object>)state;
    }
