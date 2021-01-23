    public class CookieTempDataProvider : ITempDataProvider
    {
        public const string TempDataCookieKey = "__ControllerTempData";
        public IDictionary<string, object> LoadTempData(ControllerContext controller)
        {
            HttpCookie cookie = controller.HttpContext.Request.Cookies[TempDataCookieKey];
            Dictionary<string, object> tempDataDictionary = new Dictionary<string, object>();
            if (cookie != null)
            {
                for (int keyIndex = 0; keyIndex < cookie.Values.Count; keyIndex++)
                {
                    string key = cookie.Values.GetKey(keyIndex);
                    if (!string.IsNullOrEmpty(key))
                    {
                        string base64Value = cookie.Values.Get(keyIndex);
                        byte[] buffer = Convert.FromBase64String(base64Value);
                        using (MemoryStream ms = new MemoryStream(buffer))
                        {
                            BinaryFormatter formatter = new BinaryFormatter();
                            object value = formatter.Deserialize(ms);
                            tempDataDictionary.Add(key, value);
                        }
                    }
                }
                cookie.Expires = DateTime.Now.AddDays(-1d); // expire cookie so no other request gets it
                controller.HttpContext.Response.SetCookie(cookie);
            }
            return tempDataDictionary;
        }
        public void SaveTempData(ControllerContext controller, IDictionary<string, object> values)
        {
            HttpCookie cookie = controller.HttpContext.Request.Cookies[TempDataCookieKey];
            bool hasValues = (values != null && values.Count > 0);
            if (cookie == null)
            {
                cookie = new HttpCookie(TempDataCookieKey);
                controller.HttpContext.Response.Cookies.Add(cookie);
            }
            if (hasValues)
            {
                foreach (KeyValuePair<string, object> kvp in values)
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    using (MemoryStream ms = new MemoryStream())
                    {
                        formatter.Serialize(ms, kvp.Value);
                        byte[] bytes = ms.GetBuffer();
                        string base64Value = Convert.ToBase64String(bytes);
                        string keyExists = cookie.Values.Get(kvp.Key);
                        if (keyExists != null)
                        {
                            cookie.Values.Set(kvp.Key, base64Value);
                        }
                        else
                        {
                            cookie.Values.Add(kvp.Key, base64Value);
                        }
                    }
                }
                cookie.Expires = DateTime.Now.AddDays(1d);
                controller.HttpContext.Response.SetCookie(cookie);
            }
            else
            {
                // delete session if null values are passed
                if (controller.HttpContext.Request.Cookies[TempDataCookieKey] != null)
                {
                    cookie.Expires = DateTime.Now.AddDays(-1d); // expire cookie so no other request gets it
                }
            }
        }
    }
