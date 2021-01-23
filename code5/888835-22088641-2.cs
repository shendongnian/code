    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string getData()
    {
        string data = GetJson();
        return data;
    }
    public static string GetJson()
    {
        List<LanguageData> dataList = new List<LanguageData>();
        LanguageData data1 = new LanguageData();
        data1.pkLanguageID = 1;
        data1.Language = "Language1";
        dataList.Add(data1);
        LanguageData data2 = new LanguageData();
        data2.pkLanguageID = 2;
        data2.Language = "Language2";
        dataList.Add(data2);
        System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
        return js.Serialize(dataList);
    }
    public class LanguageData
        {
            public int pkLanguageID { get; set; }
    
            public string Language { get; set; }
        }
    
