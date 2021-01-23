    using System.Web.Script.Serialization;
    // ...
    protected string numArrayJson()
    {
        int [] hi = {1,2};
        var serializer = new JavaScriptSerializer();
        var json = serializer.Serialize(hi);
        return json;
    }
