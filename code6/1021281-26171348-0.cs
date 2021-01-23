    public class MyJObjectComparer : IComparer<JObject>
    {
        public int Compare(JObject a, JObject b)
        {
            if ((a["Column1"] == b["Column1"]) && a["Column2"] == b["Column2"]))
                return 0;
    
            if ((a["Column1"] < b["Columnq"]) || ((a["Column1"] == b["Column1"]) && (a["Column2"] < b["Column2"])))
                return -1;
    
            return 1;
        }
    }
