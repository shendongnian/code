    void Main()
    {
        dynamic obj = new ExpandoObject();
        var dict = (IDictionary<string, object>)obj;
        dict["propName1"] = "test";
        dict["propName2"] = 24;
    
        Debug.WriteLine("propName1=" + (object)obj.propName1);
        Debug.WriteLine("propName2=" + (object)obj.propName2);
    }
