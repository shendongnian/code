    public class JS
    {
        public static string GetJSON(object obj)
        {
            string retJSON = JsonConvert.SerializeObject(obj);
            return retJSON;
        }
    }
