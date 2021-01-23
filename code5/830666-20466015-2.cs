    public static string GetJSONSerializedObject(object myItem)
    {
        try
        {
            if (myItem != null)
            {
                List<KeyValuePair<string, string>> _propList = new List<KeyValuePair<string, string>>();
                Type myObjectType = myItem.GetType();
                //Get public properties
                System.Reflection.PropertyInfo[] _propertyInfo =
                     myObjectType.GetProperties();
                foreach (System.Reflection.PropertyInfo _property in _propertyInfo)
                {
                    string _key = String.Empty;
                    string _value = String.Empty;
                    _key = _property.Name.ToString();
                    _value = (_property.GetValue(myItem, null) != null) ? Convert.ToString(_property.GetValue(myItem, null)) : "";
                    _propList.Add(new KeyValuePair<string, string>(_key, _value));
                }
                if (_propList.Count > 0)
                {// Serializing an object's properties
                   System.Web.Script.Serialization.JavaScriptSerializer jsSerializer;
                    jsSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    System.Text.StringBuilder _strBuild = new System.Text.StringBuilder();
                    jsSerializer.Serialize(_propList, _strBuild);
                    return _strBuild.ToString();
                }
                else { return null; }
            }
            else { return null; }
        }
        catch (Exception excp)
        {
            Common.WriteErrorLog(excp.Message);
            return null;
        }
    }
                    
