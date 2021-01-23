    public static string fromListToJSONArray(IEnumerable<dynamic> listToUse)
        {
            string JSONString = "[";
            foreach (var item in listToUse)
            {
                if(isFirst == true){
                    JSONString += "\"" + item[0] + "\"";
                    isFirst = false;
                }else
                    JSONString += ",\"" + item[0] + "\"";
            }
            JSONString += "]";
            return JSONString;
        }
