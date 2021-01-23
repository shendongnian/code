    public class CustomParameters
    {
        //Private variables
        private Dictionary<string, string> dParams;
        //Constructor
        public CustomParameters()
        {
            //Reset the dictionary
            dParams = new Dictionary<string, string>();
        }
        public CustomParameters(IDictionary savedState)
        {
            string sKey = "";
            string sValue = "";
            //Import saved state data
            if (dParams == null) dParams = new Dictionary<string, string>();
            foreach (var entry in (dynamic)savedState)
            {
                object dKey = entry.Key;
                object dValue = entry.Value;
                switch (dKey.GetType().ToString())
                {
                    case "System.String":
                        //Save the key
                        sKey = (string)dKey;
                        switch (dValue.GetType().ToString())
                        {
                            case "System.String":
                                //Save the string value
                                sValue = (string)dValue;
                                break;
                            case "System.Int32":
                                //Save the int value
                                sValue = ((int)dValue).ToString();
                                break;
                        }
                        break;
                }
                //Save the keypair to the global dictionary
                dParams.Add(sKey, sValue);
            }
        }
        //Public functions
        public void Add(string sParameterKey, string sParameterValue)
        {
            if (dParams == null) return;
            //Add or update the key
            dParams[sParameterKey] = sParameterValue;
        }
        public void Delete(string sParameterKey)
        {
            if (dParams == null) return;
            //Delete the key if it exists
            if (dParams.ContainsKey(sParameterKey))
            {
                dParams.Remove(sParameterKey);
            }
        }
        public void SaveState(IDictionary savedState)
        {
            if (dParams == null) return;
            foreach (KeyValuePair<string, string> param in dParams)
            {
                if (savedState.Contains(param.Key) == true)
                    savedState[param.Key] = param.Value;
                else
                    savedState.Add(param.Key, param.Value);
            }
        }
        public string GetValue(string sKey)
        {
            if (dParams.ContainsKey(sKey))
            {
                return dParams[sKey].ToString();
            }
            else
            {
                return "";
            }
        }
    }
